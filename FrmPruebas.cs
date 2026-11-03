//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================

using SistemaBiblioteca1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data; 
using System.Drawing; 
using System.Text; 
using System.Windows.Forms; 
 
namespace SistemaBiblioteca1
{
    public partial class FrmPruebas : Form
    {
        public FrmPruebas()
        {
            InitializeComponent();
            EjecutarPruebas();
        }

        private void EjecutarPruebas()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.AppendLine("=== PRUEBAS DE MODELOS - SISTEMA DE BIBLIOTECA ===");
            resultado.AppendLine(new string('=', 60));
            resultado.AppendLine();

            
            Usuario usuario1 = new Usuario(1, "Juan", "Pérez", "juan.perez@correo.com",
                                            "3312345678", "A00123456", true);
            resultado.AppendLine("--- Prueba 1: Usuario válido ---");
            resultado.AppendLine(usuario1.ToString());
            resultado.AppendLine();

            
            resultado.AppendLine("--- Prueba 2: Usuario inválido (excepción esperada) ---");
            try
            {
                Usuario usuarioInvalido = new Usuario(2, "", "López", "correo_malo",
                                                       "123", "A00999999", true);
            }
            catch (ArgumentException ex)
            {
                resultado.AppendLine($"[Excepción capturada] {ex.Message}");
            }
            resultado.AppendLine();

            Prestamo prestamo1 = new Prestamo(1, 1, 1, DateTime.Now.AddDays(-20),
                                               DateTime.Now.AddDays(-10), true);
            resultado.AppendLine("--- Prueba 3: Préstamo con retraso ---");
            resultado.AppendLine(prestamo1.ToString());
            resultado.AppendLine($"Retraso con fecha externa (hoy): {prestamo1.CalcularDiasRetraso(DateTime.Now)} días");
            resultado.AppendLine();

            
            Ejemplar ejemplar1 = new Ejemplar(1, 1, "EJ-001", "Dañado", false, true);
            resultado.AppendLine("--- Prueba 4: Ejemplar dañado ---");
            resultado.AppendLine(ejemplar1.ToString());
            resultado.AppendLine($"Penalización por defecto: {ejemplar1.CalcularPorcentajePenalizacion() * 100}%");
            resultado.AppendLine($"Penalización personalizada: {ejemplar1.CalcularPorcentajePenalizacion(0.30, 0.90) * 100}%");
            resultado.AppendLine();

            
            int diasRetraso = prestamo1.CalcularDiasRetraso(DateTime.Now);
            double porcentajeDano = ejemplar1.CalcularPorcentajePenalizacion();
            Sancion sancion1 = new Sancion(1, 1, 1, "Retraso y daño en el ejemplar",
                                            diasRetraso, porcentajeDano, true);
            resultado.AppendLine("--- Prueba 5: Sanción generada ---");
            resultado.AppendLine(sancion1.ToString());
            resultado.AppendLine($"Monto recalculado con tarifa especial ($15/día): ${sancion1.CalcularMonto(15):0.00}");
            resultado.AppendLine();

            
            resultado.AppendLine("--- Prueba 6: Acumulación de sanciones hasta el baneo ---");
            for (int i = 1; i <= 5; i++)
            {
                usuario1.RegistrarSancion();
                resultado.AppendLine($"Sanción {i} -> Contador: {usuario1.ContadorSanciones}, Baneado: {usuario1.EstaBaneado}, Estado: {usuario1.Estado}");
            }
            resultado.AppendLine();

            
            Pago pago1 = new Pago(1, 1, 150, "Tarjeta", true);
            resultado.AppendLine("--- Prueba 7: Pago ---");
            resultado.AppendLine(pago1.ToString());
            resultado.AppendLine($"¿Cubre sanción de $200 sin descuento? {pago1.CubreSancion(200)}");
            resultado.AppendLine($"¿Cubre sanción de $200 con descuento de $60? {pago1.CubreSancion(200, 60)}");
            resultado.AppendLine();
            resultado.AppendLine(new string('=', 60));
            resultado.AppendLine("=== FIN DE PRUEBAS ===");

            txtResultados.Text = resultado.ToString();
        }
    }
}