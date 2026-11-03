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
    public class Sancion : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<Sancion> listaSanciones = new List<Sancion>();

        private int idUsuario;
        private int idPrestamo;
        private string motivo;
        private int diasRetraso;
        private double porcentajePenalizacionCondicion;
        private double monto;
        private DateTime fechaInicio;
        private DateTime fechaFinDesactivacion;
        private bool pagada;

        private const double TARIFA_BASE_POR_DIA = 10.0;
        private const int DIAS_DESACTIVACION_DEFECTO = 15;

        public int IdSancion
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

        public int IdPrestamo
        {
            get { return idPrestamo; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un préstamo válido.");
                idPrestamo = value;
            }
        }

        public string Motivo
        {
            get { return motivo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El motivo no puede estar vacío.");
                motivo = value.Trim();
            }
        }

        public int DiasRetraso
        {
            get { return diasRetraso; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Los días de retraso no pueden ser negativos.");
                diasRetraso = value;
            }
        }

        public double PorcentajePenalizacionCondicion
        {
            get { return porcentajePenalizacionCondicion; }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException("El porcentaje debe estar entre 0 y 1.");
                porcentajePenalizacionCondicion = value;
            }
        }

        public double Monto
        {
            get { return monto; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("El monto no puede ser negativo.");
                monto = value;
            }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFinDesactivacion
        {
            get { return fechaFinDesactivacion; }
            set
            {
                if (value < fechaInicio)
                    throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.");
                fechaFinDesactivacion = value;
            }
        }

        public bool Pagada
        {
            get { return pagada; }
            set { pagada = value; }
        }

        public bool Estado
        {
            get { return EsActivo; }
            set { EsActivo = value; }
        }

        public Sancion() : base()
        {
            idUsuario = 0;
            idPrestamo = 0;
            motivo = string.Empty;
            diasRetraso = 0;
            porcentajePenalizacionCondicion = 0.0;
            monto = 0.0;
            fechaInicio = DateTime.Now;
            fechaFinDesactivacion = DateTime.Now.AddDays(DIAS_DESACTIVACION_DEFECTO);
            pagada = false;
            EsActivo = false;
        }

        public Sancion(int idSancion, int idUsuario, int idPrestamo, string motivo,
                       int diasRetraso, double porcentajePenalizacionCondicion, bool estado) : base(idSancion)
        {
            IdUsuario = idUsuario;
            IdPrestamo = idPrestamo;
            Motivo = motivo;
            DiasRetraso = diasRetraso;
            PorcentajePenalizacionCondicion = porcentajePenalizacionCondicion;
            FechaInicio = DateTime.Now;
            FechaFinDesactivacion = DateTime.Now.AddDays(DIAS_DESACTIVACION_DEFECTO);
            Pagada = false;
            EsActivo = estado;
            Monto = CalcularMonto();
        }

        public double CalcularMonto()
        {
            double resultado = CalcularMonto(TARIFA_BASE_POR_DIA);
            Monto = resultado;
            return resultado;
        }

        public double CalcularMonto(double tarifaPorDia)
        {
            if (tarifaPorDia < 0)
                throw new ArgumentException("La tarifa por día no puede ser negativa.");
            double baseMonto = diasRetraso * tarifaPorDia;
            double baseCalculoRecargo = (baseMonto > 0) ? baseMonto : tarifaPorDia;
            double recargo = baseCalculoRecargo * porcentajePenalizacionCondicion;

            double resultado = baseMonto + recargo;
            Monto = resultado;
            return resultado;
        }

        public void RegistrarPago()
        {
            pagada = true;
        }

        public void InsertarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a insertar no puede ser nulo.");

            if (!(objeto is Sancion sancion))
                throw new ArgumentException("El objeto a insertar no es de tipo Sancion.");

            if (listaSanciones.Any(s => s.Id == sancion.Id))
                throw new InvalidOperationException($"Ya existe una sanción con el id {sancion.Id}.");

            listaSanciones.Add(sancion);
        }

        public object ConsultarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);
            return listaSanciones.FirstOrDefault(s => s.Id == idBuscado);
        }

        public void ActualizarRegistro(object objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto), "El objeto a actualizar no puede ser nulo.");

            if (!(objeto is Sancion sancion))
                throw new ArgumentException("El objeto a actualizar no es de tipo Sancion.");

            int indice = listaSanciones.FindIndex(s => s.Id == sancion.Id);
            if (indice == -1)
                throw new InvalidOperationException($"No existe una sanción con el id {sancion.Id}.");

            listaSanciones[indice] = sancion;
        }

        public void EliminarRegistro(string id)
        {
            int idBuscado = ConvertirId(id);

            int indice = listaSanciones.FindIndex(s => s.Id == idBuscado);
            if (indice == -1)
                throw new InvalidOperationException($"No existe una sanción con el id {idBuscado}.");

            listaSanciones.RemoveAt(indice);
        }

        private static int ConvertirId(string id)
        {
            if (!int.TryParse(id, out int resultado) || resultado < 0)
                throw new ArgumentException("El id debe ser un número entero no negativo.");
            return resultado;
        }

        public override string ToString()
        {
            return $"Sanción #{Id} | Usuario #{idUsuario} | Motivo: {motivo} | " +
                   $"Retraso: {diasRetraso} días | Monto: ${monto:0.00} | Pagada: {pagada} | " +
                   $"Reactiva: {fechaFinDesactivacion:d}";
        }
    }
}