//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca1.Models
{
    public class Administrador : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<Administrador> listaAdministradores = new List<Administrador>();

        private string nombre;
        private string apellido;
        private string usuarioAcceso;
        private string contrasena;
        private int nivelAcceso;

      
        public int IdAdministrador
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

        public string UsuarioAcceso
        {
            get { return usuarioAcceso; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 4)
                    throw new ArgumentException("El usuario de acceso debe tener al menos 4 caracteres.");
                usuarioAcceso = value.Trim();
            }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                    throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
                contrasena = value;
            }
        }

        public int NivelAcceso
        {
            get { return nivelAcceso; }
            set
            {
                if (value < 1 || value > 3)
                    throw new ArgumentException("El nivel de acceso debe estar entre 1 y 3.");
                nivelAcceso = value;
            }
        }

        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }

        public Administrador() : base()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            usuarioAcceso = string.Empty;
            contrasena = string.Empty;
            nivelAcceso = 1;
            EsActivo = false;
        }

        public Administrador(int idAdministrador, string nombre, string apellido, string usuarioAcceso,
                             string contrasena, int nivelAcceso, bool estado) : base(idAdministrador)
        {
            Nombre = nombre;
            Apellido = apellido;
            UsuarioAcceso = usuarioAcceso;
            Contrasena = contrasena;
            NivelAcceso = nivelAcceso;
            EsActivo = estado;
        }

        public bool TienePermiso()
        {
            return TienePermiso(3);
        }

        public bool TienePermiso(int nivelRequerido)
        {
            return EsActivo && nivelAcceso >= nivelRequerido;
        }

        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a insertar no puede ser nulo.");

            if (!(objeto is Administrador administrador))
                throw new ArgumentException("El objeto a insertar no es de tipo Administrador.");

            if (listaAdministradores.Any(a => a.Id == administrador.Id))
                throw new InvalidOperationException($"Ya existe un administrador con el id {administrador.Id}.");

            listaAdministradores.Add(administrador);
        }

        public object ConsultarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);
            return listaAdministradores.FirstOrDefault(a => a.Id == idBuscado); 
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a actualizar no puede ser nulo.");

            if (!(objeto is Administrador administrador))
                throw new ArgumentException("El objeto a actualizar no es de tipo Administrador.");

            int indice = listaAdministradores.FindIndex(a => a.Id == administrador.Id);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un administrador con el id {administrador.Id}.");

            listaAdministradores[indice] = administrador;
        }

        public void EliminarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);

            int indice = listaAdministradores.FindIndex(a => a.Id == idBuscado);
            if (indice == -1)
                throw new InvalidOperationException($"No existe un administrador con el id {idBuscado}.");

            listaAdministradores.RemoveAt(indice);
        }

        private static int ConvertirId(string id)
        {
            if (!int.TryParse(id, out int resultado) || resultado < 0)
                throw new ArgumentException("El id debe ser un número entero no negativo.");
            return resultado;
        }

        public override string ToString()
        {
            return $"Administrador #{Id}: {nombre} {apellido} | Usuario: {usuarioAcceso} | " +
                   $"Nivel: {nivelAcceso} | Estado: {(EsActivo ? "Activo" : "Inactivo")}";
        }
    }
}