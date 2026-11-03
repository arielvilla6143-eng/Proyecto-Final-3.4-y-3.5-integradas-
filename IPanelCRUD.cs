// Actividad 2.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
using System;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    /// <summary>
    /// Contrato visual que deben cumplir todos los formularios heredados de FrmBase
    /// Permite que FrmMaestro controle cualquier vista sin conocer su clase
    /// </summary>
    public interface IPanelCRUD
    {
        void EjecutarGuardar();
        void EjecutarBuscar(string id, ErrorProvider alerta);
        void EjecutarActualizar();
        void EjecutarEliminar(StatusStrip barraEstado);
    }
}