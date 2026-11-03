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
    /// <summary>
    /// Clase base abstracta de la que heredan todas las entidades del sistema.
    /// Concentra los atributos comunes: identificador, fecha de registro y estado.
    /// </summary>
    public abstract class EntidadBase
    {
        private int _id;

        /// <summary>
        /// Identificador único de la entidad. No puede ser negativo.
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El identificador no puede ser un numero negativo.");
                }
                _id = value;
            }
        }

        /// <summary>
        /// Fecha y hora en que se creó el registro. Se asigna automáticamente.
        /// </summary>
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        /// <summary>
        /// Indica si el registro está activo. Por defecto es verdadero.
        /// </summary>
        public bool EsActivo { get; set; } = true;

        /// <summary>
        /// Constructor por defecto. Usado por las clases derivadas.
        /// </summary>
        protected EntidadBase()
        {
        }

        /// <summary>
        /// Constructor que inicializa el identificador de la entidad.
        /// </summary>
        /// <param name="id">Identificador de la entidad (no negativo).</param>
        protected EntidadBase(int id)
        {
            Id = id;
        }
    }
}