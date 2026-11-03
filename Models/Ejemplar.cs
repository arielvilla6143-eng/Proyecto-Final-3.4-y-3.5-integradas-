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
    public class Ejemplar : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<Ejemplar> listaEjemplares = new List<Ejemplar>();

        private int idLibro;
        private string codigoInventario;
        private string condicion;
        private bool disponible;

        public int IdEjemplar
        {
            get { return Id; }
            set { Id = value; }
        }

        public int IdLibro
        {
            get { return idLibro; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un libro válido.");
                idLibro = value;
            }
        }

        public string CodigoInventario
        {
            get { return codigoInventario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length > 12)
                    throw new ArgumentException("El código de inventario no puede estar vacío ni exceder 12 caracteres.");
                codigoInventario = value.Trim();
            }
        }

        public string Condicion
        {
            get { return condicion; }
            set
            {
                string v = (value ?? string.Empty).Trim();
                if (v != "Nuevo" && v != "Bueno" && v != "Regular" && v != "Dañado")
                    throw new ArgumentException("La condición debe ser: Nuevo, Bueno, Regular o Dañado.");
                condicion = v;
            }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }

        public Ejemplar() : base()
        {
            idLibro = 0;
            codigoInventario = string.Empty;
            condicion = "Nuevo";
            disponible = true;
            EsActivo = false;
        }

        public Ejemplar(int idEjemplar, int idLibro, string codigoInventario, string condicion,
                        bool disponible, bool estado) : base(idEjemplar)
        {
            IdLibro = idLibro;
            CodigoInventario = codigoInventario;
            Condicion = condicion;
            Disponible = disponible;
            EsActivo = estado;
        }

        public double CalcularPorcentajePenalizacion()
        {
            switch (condicion)
            {
                case "Nuevo":
                case "Bueno":
                    return 0.0;
                case "Regular":
                    return 0.20;
                case "Dañado":
                    return 0.75;
                default:
                    return 0.0;
            }
        }

        public double CalcularPorcentajePenalizacion(double tarifaRegular, double tarifaDanado)
        {
            switch (condicion)
            {
                case "Regular":
                    return tarifaRegular;
                case "Dañado":
                    return tarifaDanado;
                default:
                    return 0.0;
            }
        }

        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a insertar no puede ser nulo.");

            if (!(objeto is Ejemplar ejemplar))
                throw new ArgumentException("El objeto a insertar no es de tipo Ejemplar.");

            if (listaEjemplares.Any(e => e.Id == ejemplar.Id))
                throw new InvalidOperationException($"Ya existe un ejemplar con el id {ejemplar.Id}.");

            listaEjemplares.Add(ejemplar);
        }

        public object ConsultarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);
            return listaEjemplares.FirstOrDefault(e => e.Id == idBuscado);
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a actualizar no puede ser nulo.");

            if (!(objeto is Ejemplar ejemplar))
                throw new ArgumentException("El objeto a actualizar no es de tipo Ejemplar.");

            int indice = listaEjemplares.FindIndex(e => e.Id == ejemplar.Id);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un ejemplar con el id {ejemplar.Id}.");

            listaEjemplares[indice] = ejemplar;
        }

        public void EliminarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);

            int indice = listaEjemplares.FindIndex(e => e.Id == idBuscado);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un ejemplar con el id {idBuscado}.");

            listaEjemplares.RemoveAt(indice);
        }

        private static int ConvertirId(string id)
        {
            if (!int.TryParse(id, out int resultado) || resultado < 0)
                throw new ArgumentException("El id debe ser un número entero no negativo.");
            return resultado;
        }

        public override string ToString()
        {
            return $"Ejemplar #{Id} (Libro #{idLibro}) | Código: {codigoInventario} | " +
                   $"Condición: {condicion} | Disponible: {disponible} | Estado: {(EsActivo ? "Activo" : "Inactivo")}";
        }
    }
}