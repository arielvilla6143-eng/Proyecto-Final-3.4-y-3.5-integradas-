//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1.Models
{
    public class Libro : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<Libro> listaLibros = new List<Libro>();

        private string titulo;
        private string isbn;
        private int idAutor;
        private int idCategoria;
        private int idEditorial;
        private int anioPublicacion;

        public int IdLibro
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El título no puede estar vacío.");
                titulo = value.Trim();
            }
        }

        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length != 10 && value.Length != 13))
                    throw new ArgumentException("El ISBN debe tener 10 o 13 caracteres.");
                isbn = value.Trim();
            }
        }

        public int IdAutor
        {
            get { return idAutor; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un autor válido.");
                idAutor = value;
            }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse una categoría válida.");
                idCategoria = value;
            }
        }

        public int IdEditorial
        {
            get { return idEditorial; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse una editorial válida.");
                idEditorial = value;
            }
        }

        public int AnioPublicacion
        {
            get { return anioPublicacion; }
            set
            {
                if (value < 1400 || value > DateTime.Now.Year)
                    throw new ArgumentException("El año de publicación no es válido.");
                anioPublicacion = value;
            }
        }

        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }

        public Libro() : base()
        {
            titulo = string.Empty;
            isbn = string.Empty;
            idAutor = 0;
            idCategoria = 0;
            idEditorial = 0;
            anioPublicacion = DateTime.Now.Year;
            EsActivo = false;
        }

        public Libro(int idLibro, string titulo, string isbn, int idAutor, int idCategoria,
                     int idEditorial, int anioPublicacion, bool estado) : base(idLibro)
        {
            Titulo = titulo;
            Isbn = isbn;
            IdAutor = idAutor;
            IdCategoria = idCategoria;
            IdEditorial = idEditorial;
            AnioPublicacion = anioPublicacion;
            EsActivo = estado;
        }

        public int CalcularAntiguedad()
        {
            return CalcularAntiguedad(DateTime.Now.Year);
        }

        public int CalcularAntiguedad(int anioReferencia)
        {
            if (anioReferencia < anioPublicacion)
                throw new ArgumentException("El año de referencia no puede ser anterior a la publicación.");
            return anioReferencia - anioPublicacion;
        }

        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a insertar no puede ser nulo.");

            if (!(objeto is Libro libro))
                throw new ArgumentException("El objeto a insertar no es de tipo Libro.");

            if (listaLibros.Any(l => l.Id == libro.Id))
                throw new InvalidOperationException($"Ya existe un libro con el id {libro.Id}.");

            listaLibros.Add(libro);
        }

        public object ConsultarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);
            return listaLibros.FirstOrDefault(l => l.Id == idBuscado);
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a actualizar no puede ser nulo.");

            if (!(objeto is Libro libro))
                throw new ArgumentException("El objeto a actualizar no es de tipo Libro.");

            int indice = listaLibros.FindIndex(l => l.Id == libro.Id);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un libro con el id {libro.Id}.");

            listaLibros[indice] = libro;
        }

        public void EliminarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);

            int indice = listaLibros.FindIndex(l => l.Id == idBuscado);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un libro con el id {idBuscado}.");

            listaLibros.RemoveAt(indice);
        }

        private static int ConvertirId(string id)
        {
            if (!int.TryParse(id, out int resultado) || resultado < 0)
                throw new ArgumentException("El id debe ser un número entero no negativo.");
            return resultado;
        }

        public override string ToString()
        {
            return $"Libro #{Id}: {titulo} | ISBN: {isbn} | Año: {anioPublicacion} | " +
                   $"Estado: {(EsActivo ? "Disponible en catálogo" : "Dado de baja")}";
        }
    }
}