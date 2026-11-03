//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using SistemaBiblioteca1.Models;
using System; 
using System.Collections.Generic; 
using System.Text;

namespace SistemaBiblioteca1.Models
{
    public class Categoria : EntidadBase, IAlmacenamientoCRUD
    {
       
        private static List<Categoria> listaCategorias = new List<Categoria>();

        private string nombre;
        private string descripcion;
        private bool restringidaMenores;
        public int IdCategoria
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la categoría no puede estar vacío.");
                nombre = value.Trim();
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value ?? string.Empty; }
        }

        public bool RestringidaMenores
        {
            get { return restringidaMenores; }
            set { restringidaMenores = value; }
        }
        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }
        public Categoria() : base()
        {
            nombre = string.Empty;
            descripcion = string.Empty;
            restringidaMenores = false;
            EsActivo = false;
        }

        public Categoria(int idCategoria, string nombre, string descripcion,
                         bool restringidaMenores, bool estado) : base(idCategoria)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            RestringidaMenores = restringidaMenores;
            EsActivo = estado;
        }

        public bool PermiteAcceso(int edadUsuario)
        {
            return PermiteAcceso(edadUsuario, 18);
        }

        public bool PermiteAcceso(int edadUsuario, int edadMinima)
        {
            if (!restringidaMenores)
                return true;
            return edadUsuario >= edadMinima;
        }
        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a insertar no puede ser nulo.");

            if (!(objeto is Categoria categoria))
                throw new ArgumentException("El objeto a insertar no es de tipo Categoria.");

            if (listaCategorias.Any(c => c.Id == categoria.Id))
                throw new InvalidOperationException($"Ya existe una categoría con el id {categoria.Id}.");

            listaCategorias.Add(categoria);
        }

        public object ConsultarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);
            return listaCategorias.FirstOrDefault(c => c.Id == idBuscado);
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a actualizar no puede ser nulo.");

            if (!(objeto is Categoria categoria))
                throw new ArgumentException("El objeto a actualizar no es de tipo Categoria.");

            int indice = listaCategorias.FindIndex(c => c.Id == categoria.Id);
            if (indice == -1)
                throw new InvalidOperationException($"No existe una categoría con el id {categoria.Id}.");

            listaCategorias[indice] = categoria;
        }

        public void EliminarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);

            int indice = listaCategorias.FindIndex(c => c.Id == idBuscado);
            if (indice == -1)
                throw new InvalidOperationException($"No existe una categoría con el id {idBuscado}.");

            listaCategorias.RemoveAt(indice);
        }
        private static int ConvertirId(string id)
        {
            if (!int.TryParse(id, out int resultado) || resultado < 0)
                throw new ArgumentException("El id debe ser un número entero no negativo.");
            return resultado;
        }

        public override string ToString()
        {
            return $"Categoría #{Id}: {nombre} | Restringida: {restringidaMenores} | " +
                   $"Estado: {(EsActivo ? "Activa" : "Inactiva")}";
        }
    }
}

