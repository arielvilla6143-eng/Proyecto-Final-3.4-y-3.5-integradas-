//Suñiga Maciel Joule Alexander 
//Villa Olivares Ariel 
//Nuñes Martinez Marco Antonio 
//Equipo 2 
//============================= 
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1.Models
{
    public class Usuario : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<Usuario> listaUsuarios = new List<Usuario>();

        private string nombre;
        private string apellido;
        private string email;
        private string telefono;
        private string idUniversitario;
        private int contadorSanciones;
        private bool estaBaneado;

        private const int LIMITE_SANCIONES_BANEO = 5;

        public int IdUsuario
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
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío.");
                apellido = value.Trim();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !value.Contains("."))
                    throw new ArgumentException("El correo electrónico no tiene un formato válido.");
                email = value.Trim();
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length != 10)
                    throw new ArgumentException("El teléfono debe contener 10 dígitos.");
                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                        throw new ArgumentException("El teléfono solo debe contener números.");
                }
                telefono = value.Trim();
            }
        }

        public string IdUniversitario
        {
            get { return idUniversitario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El id universitario no puede estar vacío.");
                idUniversitario = value.Trim();
            }
        }

        public int ContadorSanciones
        {
            get { return contadorSanciones; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El contador de sanciones no puede ser negativo.");
                contadorSanciones = value;
            }
        }

        public bool EstaBaneado
        {
            get { return estaBaneado; }
            set { estaBaneado = value; }
        }

        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }

        public Usuario() : base()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            email = string.Empty;
            telefono = string.Empty;
            idUniversitario = string.Empty;
            contadorSanciones = 0;
            estaBaneado = false;
            EsActivo = false;
        }

        public Usuario(int idUsuario, string nombre, string apellido, string email,
                        string telefono, string idUniversitario, bool estado) : base(idUsuario)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            IdUniversitario = idUniversitario;
            ContadorSanciones = 0;
            EstaBaneado = false;
            EsActivo = estado;
        }

        public void RegistrarSancion()
        {
            RegistrarSancion(1, LIMITE_SANCIONES_BANEO);
        }

        public void RegistrarSancion(int cantidadASumar, int limiteBaneo)
        {
            if (cantidadASumar <= 0)
                throw new ArgumentException("La cantidad a sumar debe ser mayor a cero.");

            ContadorSanciones += cantidadASumar;

            if (ContadorSanciones >= limiteBaneo)
            {
                EstaBaneado = true;
                EsActivo = false;
            }
        }

        public bool PuedeSolicitarPrestamo()
        {
            return EsActivo && !EstaBaneado;
        }

        public bool PuedeSolicitarPrestamo(int prestamosActivos, int limitePrestamos)
        {
            return PuedeSolicitarPrestamo() && prestamosActivos < limitePrestamos;
        }

        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a insertar no puede ser nulo.");

            if (!(objeto is Usuario usuario))
                throw new ArgumentException("El objeto a insertar no es de tipo Usuario.");

            if (listaUsuarios.Any(u => u.Id == usuario.Id))
                throw new InvalidOperationException($"Ya existe un usuario con el id {usuario.Id}.");

            listaUsuarios.Add(usuario);
        }

        public object ConsultarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);
            return listaUsuarios.FirstOrDefault(u => u.Id == idBuscado);
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a actualizar no puede ser nulo.");

            if (!(objeto is Usuario usuario))
                throw new ArgumentException("El objeto a actualizar no es de tipo Usuario.");

            int indice = listaUsuarios.FindIndex(u => u.Id == usuario.Id);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un usuario con el id {usuario.Id}.");

            listaUsuarios[indice] = usuario;
        }

        public void EliminarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);

            int indice = listaUsuarios.FindIndex(u => u.Id == idBuscado);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un usuario con el id {idBuscado}.");

            listaUsuarios.RemoveAt(indice);
        }

        private static int ConvertirId(string id)
        {
            if (!int.TryParse(id, out int resultado) || resultado < 0)
                throw new ArgumentException("El id debe ser un número entero no negativo.");
            return resultado;
        }

        public override string ToString()
        {
            return $"Usuario #{Id}: {nombre} {apellido} | ID Universitario: {idUniversitario} | " +
                   $"Email: {email} | Sanciones: {contadorSanciones} | Baneado: {estaBaneado} | " +
                   $"Estado: {(EsActivo ? "Activo" : "Inactivo")}";
        }
    }
}