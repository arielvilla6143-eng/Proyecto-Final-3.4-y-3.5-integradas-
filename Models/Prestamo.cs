// SUÑIGA Maciel Joule Alexander
// VILLA Olivarez Ariel
// NUÑEZ Martinez Marco Antonio
// Equipo 2
// Actividad 2.5 - Estructura lineal Stack<T> (LIFO)
// ===============================
using SistemaBiblioteca1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SistemaBiblioteca1.Models
{
    public class Prestamo : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<Prestamo> listaPrestamos = new List<Prestamo>();

        private List<Ejemplar> _listaEjemplares;
        
        private Stack<string> _historialCambios;

        private int idUsuario;
        private int idEjemplar;
        private DateTime fechaPrestamo;
        private DateTime fechaLimite;
        private DateTime? fechaDevolucionReal;
        private bool devuelto;

        public List<Ejemplar> ListaEjemplares
        {
            get { return _listaEjemplares; }
        }

        public Stack<string> HistorialCambios
        {
            get { return _historialCambios; }
        }

        public int IdPrestamo
        {
            get { return Id; }
            set { Id = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un usuario válido.");
                idUsuario = value;
            }
        }

        public int IdEjemplar
        {
            get { return idEjemplar; }
            set { idEjemplar = value; }
        }

        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }

        public DateTime FechaLimite
        {
            get { return fechaLimite; }
            set
            {
                if (value.Date < fechaPrestamo.Date)
                    throw new ArgumentException("La fecha límite no puede ser anterior a la fecha de préstamo.");
                fechaLimite = value;
            }
        }

        public DateTime? FechaDevolucionReal
        {
            get { return fechaDevolucionReal; }
            set { fechaDevolucionReal = value; }
        }

        public bool Devuelto
        {
            get { return devuelto; }
            set
            {
                devuelto = value;
                if (devuelto && !fechaDevolucionReal.HasValue)
                {
                    fechaDevolucionReal = DateTime.Now;
                }
                else if (!devuelto)
                {
                    fechaDevolucionReal = null;
                }
            }
        }

        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }

        public Prestamo() : base()
        {
            idUsuario = 0;
            idEjemplar = 0;
            fechaPrestamo = DateTime.Now;
            fechaLimite = DateTime.Now;
            fechaDevolucionReal = null;
            devuelto = false;
            EsActivo = false;

            _listaEjemplares = new List<Ejemplar>();
            _historialCambios = new Stack<string>();
        }

        public Prestamo(int idPrestamo, int idUsuario, int idEjemplar, DateTime fechaPrestamo,
                        DateTime fechaLimite, bool estado) : base(idPrestamo)
        {
            IdUsuario = idUsuario;
            IdEjemplar = idEjemplar;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            fechaDevolucionReal = null;
            devuelto = false;
            EsActivo = estado;

            _listaEjemplares = new List<Ejemplar>();
            _historialCambios = new Stack<string>();
        }

        public void RegistrarEjemplar(Ejemplar ejemplar)
        {
            if (ejemplar == null)
                throw new ArgumentNullException(nameof(ejemplar), "El ejemplar no puede ser nulo.");

            _listaEjemplares.Add(ejemplar);
        }

        public int ContarEjemplares()
        {
            return _listaEjemplares.Count;
        }

        public Ejemplar BuscarEjemplarPorId(string id)
        {
            if (!int.TryParse(id, out int idBuscado))
                return null;

            foreach (Ejemplar item in _listaEjemplares)
            {
                if (item.Id == idBuscado)
                {
                    return item;
                }
            }
            return null;
        }

        public bool ValidarExistenciaEjemplar(string id)
        {
            if (!int.TryParse(id, out int idBuscado))
                return false;

            foreach (Ejemplar item in _listaEjemplares)
            {
                if (item.Id == idBuscado)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EliminarEjemplarPorId(string id)
        {
            if (!int.TryParse(id, out int idBuscado))
                return false;

            for (int i = 0; i < _listaEjemplares.Count; i++)
            {
                if (_listaEjemplares[i].Id == idBuscado)
                {
                    _listaEjemplares.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<Ejemplar> FiltrarEjemplaresPorEstado(bool estadoBuscado)
        {
            List<Ejemplar> filtrados = new List<Ejemplar>();

            foreach (Ejemplar item in _listaEjemplares)
            {
                if (item.EsActivo == estadoBuscado)
                {
                    filtrados.Add(item);
                }
            }

            return filtrados;
        }

        public void VaciarEjemplares()
        {
            _listaEjemplares.Clear();
        }

        public int CalcularDiasRetraso()
        {
            DateTime fechaComparacion = fechaDevolucionReal ?? DateTime.Now;
            return CalcularDiasRetraso(fechaComparacion);
        }

        public int CalcularDiasRetraso(DateTime fechaDevolucion)
        {
            TimeSpan diferencia = fechaDevolucion.Date - fechaLimite.Date;
            return diferencia.Days > 0 ? diferencia.Days : 0;
        }

        public void RegistrarDevolucion(DateTime fecha)
        {
            if (fecha.Date < fechaPrestamo.Date)
                throw new ArgumentException("La fecha de devolución no puede ser anterior al préstamo.");
            fechaDevolucionReal = fecha;
            devuelto = true;
        }
        //apilar accion
        public void ApilarAccion(string accion)
        {
            if (string.IsNullOrWhiteSpace(accion))
                throw new ArgumentException("La acción a apilar no puede estar vacía.");

            _historialCambios.Push(accion);
        }

        public bool RegistrarEstado(int idUsuario, int idEjemplar, DateTime fechaPrestamo,
                                    DateTime fechaLimite, bool devuelto, bool activo)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("Debe asignarse un usuario válido.");
            if (fechaLimite.Date < fechaPrestamo.Date)
                throw new ArgumentException("La fecha límite no puede ser anterior a la fecha de préstamo.");

            IdUsuario = idUsuario;
            IdEjemplar = idEjemplar;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            Devuelto = devuelto;
            Estado = activo;

            string estadoActual = CapturarEstadoActual();

            if (ValidarExistenciaEstado(estadoActual))
                return false;

            ApilarAccion(estadoActual);
            return true;
        }

        public string DesapilarYRevertir()
        {
            if (_historialCambios.Count == 0)
                return null;

            string retirado = _historialCambios.Pop();

            if (_historialCambios.Count > 0)
                AplicarEstado(_historialCambios.Peek());
            else
                RestablecerValoresIniciales();

            return retirado;
        }

        public string InspeccionarCima()
        {
            if (_historialCambios.Count == 0)
                return null;

            return _historialCambios.Peek();
        }

        public int ContarHistorial()
        {
            return _historialCambios.Count;
        }

        public bool ValidarExistenciaEstado(string estado)
        {
            foreach (string elemento in _historialCambios)
            {
                if (elemento == estado)
                {
                    return true;
                }
            }
            return false;
        }

        public void VaciarHistorial()
        {
            _historialCambios.Clear();
        }

        public string[] VolcarAArreglo()
        {
            Stack<string> copia = new Stack<string>(_historialCambios);
            string[] arreglo = new string[copia.Count];

            for (int i = arreglo.Length - 1; i >= 0; i--)
            {
                arreglo[i] = copia.Pop();
            }

            return arreglo; 
        }


        private string CapturarEstadoActual()
        {
            return "Usuario:" + idUsuario +
                   "|Ejemplar:" + idEjemplar +
                   "|Prestamo:" + fechaPrestamo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) +
                   "|Limite:" + fechaLimite.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) +
                   "|Devuelto:" + devuelto +
                   "|Activo:" + EsActivo;
        }

        private void AplicarEstado(string estado)
        {
            string[] partes = estado.Split('|');
            if (partes.Length != 6)
                throw new FormatException("El estado guardado en la pila no tiene el formato esperado.");

            idUsuario = int.Parse(ObtenerValor(partes[0]));
            idEjemplar = int.Parse(ObtenerValor(partes[1]));
            fechaPrestamo = DateTime.ParseExact(ObtenerValor(partes[2]), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            fechaLimite = DateTime.ParseExact(ObtenerValor(partes[3]), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            fechaDevolucionReal = null;
            Devuelto = bool.Parse(ObtenerValor(partes[4]));
            EsActivo = bool.Parse(ObtenerValor(partes[5]));
        }

        private string ObtenerValor(string campo)
        {
            return campo.Substring(campo.IndexOf(':') + 1);
        }

        private void RestablecerValoresIniciales()
        {
            idUsuario = 0;
            idEjemplar = 0;
            fechaPrestamo = DateTime.Now;
            fechaLimite = DateTime.Now;
            fechaDevolucionReal = null;
            devuelto = false;
            EsActivo = false;
        }

        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto no puede ser nulo.");

            if (!(objeto is Prestamo prestamo))
                throw new ArgumentException("El objeto debe ser de tipo Prestamo.");

            foreach (Prestamo p in listaPrestamos)
            {
                if (p.Id == prestamo.Id)
                    throw new InvalidOperationException($"Ya existe un préstamo con el id {prestamo.Id}.");
            }

            listaPrestamos.Add(prestamo);
        }

        public object ConsultarRegistro(string id)
        {
            if (!int.TryParse(id, out int idBuscado))
                throw new ArgumentException("El ID debe ser un entero no negativo.");

            foreach (Prestamo p in listaPrestamos)
            {
                if (p.Id == idBuscado)
                    return p;
            }
            return null;
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null || !(objeto is Prestamo prestamo))
                throw new ArgumentException("Objeto inválido.");

            for (int i = 0; i < listaPrestamos.Count; i++)
            {
                if (listaPrestamos[i].Id == prestamo.Id)
                {
                    listaPrestamos[i] = prestamo;
                    return;
                }
            }
            throw new InvalidOperationException($"No existe un préstamo con el id {prestamo.Id}.");
        }

        public void EliminarRegistro(string id)
        {
            if (!int.TryParse(id, out int idBuscado))
                throw new ArgumentException("El ID debe ser un entero válido.");

            for (int i = 0; i < listaPrestamos.Count; i++)
            {
                if (listaPrestamos[i].Id == idBuscado)
                {
                    listaPrestamos.RemoveAt(i);
                    return;
                }
            }
            throw new InvalidOperationException($"No existe un préstamo con el id {idBuscado}.");
        }

        public override string ToString()
        {
            string devolucionTexto = fechaDevolucionReal.HasValue
                ? fechaDevolucionReal.Value.ToShortDateString()
                : "Pendiente";
            return $"Préstamo #{Id} | Usuario #{idUsuario} | Ejemplares: {_listaEjemplares.Count} | " +
                   $"Límite: {fechaLimite:d} | Devolución: {devolucionTexto}";
        }
    }
}