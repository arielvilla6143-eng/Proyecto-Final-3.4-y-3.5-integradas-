// Actividad 3.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
using System;
using System.Diagnostics;
using System.Threading;

namespace SistemaBiblioteca1.Models
{
    public class ProgresoReporte
    {
        public int Procesados { get; set; }
        public int Total { get; set; }
        public int Sancionados { get; set; }
        public double MontoAcumulado { get; set; }

        public int Porcentaje
        {
            get { return Total == 0 ? 0 : (int)((long)Procesados * 100 / Total); }
        }
    }

    public class FilaReporte
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public int DiasRetraso { get; set; }
        public double PorcentajeRecargo { get; set; }
        public double Monto { get; set; }
    }

    public class ResumenReporte
    {
        public int Procesados { get; set; }
        public int Sancionados { get; set; }
        public double MontoTotal { get; set; }
        public int MayorRetraso { get; set; }
        public TimeSpan Duracion { get; set; }
        public bool Cancelado { get; set; }
    }

    public static class MotorReporteSanciones
    {
        private static readonly string[] Motivos =
        {
            "Devolución tardía",
            "Retraso en la entrega del ejemplar",
            "Ejemplar no devuelto a tiempo"
        };

        private static readonly double[] Recargos = { 0.10, 0.20, 0.30 };

        public static ResumenReporte Procesar(int cantidad, int retardoMs,
                                              IProgress<ProgresoReporte>? progreso,
                                              Action<FilaReporte>? alGenerarFila,
                                              CancellationToken token)
        {
            Stopwatch cronometro = Stopwatch.StartNew();

            Random azar = new Random(2026);
            DateTime hoy = DateTime.Today;
            int paso = Math.Max(1, cantidad / 100);

            int sancionados = 0;
            int mayorRetraso = 0;
            double montoTotal = 0;

            ResumenReporte ArmarResumen(int procesados, bool cancelado)
            {
                cronometro.Stop();
                return new ResumenReporte
                {
                    Procesados = procesados,
                    Sancionados = sancionados,
                    MontoTotal = montoTotal,
                    MayorRetraso = mayorRetraso,
                    Duracion = cronometro.Elapsed,
                    Cancelado = cancelado
                };
            }

            for (int i = 1; i <= cantidad; i++)
            {
                if (token.IsCancellationRequested)
                    return ArmarResumen(i - 1, true);

                DateTime fechaPrestamo = hoy.AddDays(-azar.Next(10, 90));
                DateTime fechaLimite = fechaPrestamo.AddDays(azar.Next(0, 2) == 0 ? 7 : 14);

                Prestamo prestamo = new Prestamo(i, azar.Next(1, 501), azar.Next(1, 2001),
                                                 fechaPrestamo, fechaLimite, true);

                if (azar.Next(100) < 70)
                {
                    DateTime devolucion = fechaLimite.AddDays(azar.Next(-3, 21));
                    if (devolucion > hoy)
                        devolucion = hoy;
                    prestamo.RegistrarDevolucion(devolucion);
                }

                int diasRetraso = prestamo.CalcularDiasRetraso();
                if (diasRetraso > 0)
                {
                    double recargo = Recargos[azar.Next(Recargos.Length)];
                    Sancion sancion = new Sancion(i, prestamo.IdUsuario, prestamo.Id,
                                                  Motivos[azar.Next(Motivos.Length)],
                                                  diasRetraso, recargo, true);

                    sancionados++;
                    montoTotal += sancion.Monto;
                    if (diasRetraso > mayorRetraso)
                        mayorRetraso = diasRetraso;

                    if (alGenerarFila != null)
                    {
                        alGenerarFila(new FilaReporte
                        {
                            IdPrestamo = prestamo.Id,
                            IdUsuario = prestamo.IdUsuario,
                            DiasRetraso = diasRetraso,
                            PorcentajeRecargo = recargo,
                            Monto = sancion.Monto
                        });
                    }
                }

                if (retardoMs > 0 && token.WaitHandle.WaitOne(retardoMs))
                    return ArmarResumen(i, true);

                if (progreso != null && (i % paso == 0 || i == cantidad))
                {
                    progreso.Report(new ProgresoReporte
                    {
                        Procesados = i,
                        Total = cantidad,
                        Sancionados = sancionados,
                        MontoAcumulado = montoTotal
                    });
                }
            }

            return ArmarResumen(cantidad, false);
        }
    }
}