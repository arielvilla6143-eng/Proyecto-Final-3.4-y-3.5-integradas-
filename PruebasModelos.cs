//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using SistemaBiblioteca1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca1
{
    public static class PruebasModelos
    {
        private static int correctas = 0;
        private static int fallidas = 0;

        public static void Mostrar()
        {
            string reporte = EjecutarPruebas();

            Form ventana = new Form();
            ventana.Text = "Pruebas de la Actividad 2.3";
            ventana.Width = 950;
            ventana.Height = 750;
            ventana.StartPosition = FormStartPosition.CenterScreen;

            TextBox caja = new TextBox();
            caja.Multiline = true;
            caja.ReadOnly = true;
            caja.WordWrap = false;
            caja.ScrollBars = ScrollBars.Both;
            caja.Dock = DockStyle.Fill;
            caja.Font = new Font("Consolas", 10);
            caja.Text = reporte;
            caja.SelectionStart = 0;
            caja.SelectionLength = 0;

            ventana.Controls.Add(caja);
            ventana.ShowDialog();
        }
        private static List<(string Nombre, Func<bool, EntidadBase> Crear)> Fabricas()
        {
            DateTime hoy = DateTime.Today;

            return new List<(string Nombre, Func<bool, EntidadBase> Crear)>
            {
                ("Administrador", estado => new Administrador(1, "Ana", "Lopez", "alopez", "clave123", 2, estado)),
                ("Autor", estado => new Autor(1, "Gabriel", "Garcia", "Colombiana", new DateTime(1927, 3, 6), estado)),
                ("Categoria", estado => new Categoria(1, "Novela", "Narrativa de ficcion", false, estado)),
                ("Editorial", estado => new Editorial(1, "Editorial Uno", "Mexico", 2007, estado)),
                ("Ejemplar", estado => new Ejemplar(1, 1, "INV-0001", "Bueno", true, estado)),
                ("Libro", estado => new Libro(1, "Cien anios de soledad", "9788457089895", 1, 1, 1, 1967, estado)),
                ("Pago", estado => new Pago(1, 1, 50.0, "Efectivo", estado)),
                ("Prestamo", estado => new Prestamo(1, 1, 1, hoy, hoy.AddDays(7), estado)),
                ("Sancion", estado => new Sancion(1, 1, 1, "Retraso", 3, 0.20, estado)),
                ("Usuario", estado => new Usuario(1, "Luis", "Perez", "luis@correo.com", "3312345678", "U-001", estado))
            };
        }

        private static string EjecutarPruebas()
        {
            correctas = 0;
            fallidas = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PRUEBAS DE LA ACTIVIDAD 2.3 CAPA MODEL");
            sb.AppendLine("Fecha y hora: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(new string('=', 78));

            var fabricas = Fabricas();

            sb.AppendLine();
            sb.AppendLine("HERENCIA (EntidadBase) Y POLIMORFISMO (IAlmacenamientoCRUD)");
            foreach (var f in fabricas)
            {
                EntidadBase entidad = f.Crear(true);
                bool cumpleContrato = entidad is IAlmacenamientoCRUD;
                Verificar(sb, f.Nombre + " hereda de EntidadBase e implementa IAlmacenamientoCRUD", cumpleContrato);
                Verificar(sb, f.Nombre + ": Id=" + entidad.Id + ", EsActivo=" + entidad.EsActivo +
                              ", FechaRegistro asignada automaticamente",
                          entidad.FechaRegistro != default(DateTime) && entidad.EsActivo);
            }

            sb.AppendLine();
            sb.AppendLine("CRUD EN MEMORIA DE LAS 10 ENTIDADES (IAlmacenamientoCRUD)");
            foreach (var f in fabricas)
            {
                try
                {
                    EntidadBase original = f.Crear(true);
                    IAlmacenamientoCRUD crud = (IAlmacenamientoCRUD)original;
                    string id = original.Id.ToString();

                    crud.InsertarRegistro(original);
                    Verificar(sb, f.Nombre + ": Insertar y Consultar",
                              ReferenceEquals(crud.ConsultarRegistro(id), original));

                    crud.ActualizarRegistro(f.Crear(false));
                    EntidadBase actualizado = (EntidadBase)crud.ConsultarRegistro(id);
                    Verificar(sb, f.Nombre + ": Actualizar (EsActivo cambio de true a false)",
                              actualizado != null && !actualizado.EsActivo);

                    crud.EliminarRegistro(id);
                    Verificar(sb, f.Nombre + ": Eliminar (ya no se encuentra)",
                              crud.ConsultarRegistro(id) == null);
                }
                catch (Exception ex)
                {
                    Verificar(sb, f.Nombre + ": CRUD sin excepciones (" + ex.GetType().Name + ": " + ex.Message + ")", false);
                }
            }

            sb.AppendLine();
            sb.AppendLine("CASOS DE ERROR DEL CRUD ");
            try
            {
                Autor autor = new Autor(1, "Ana", "Lopez", "Mexicana", new DateTime(1950, 5, 20), true);
                Libro libro = new Libro(1, "Titulo", "9788457089895", 1, 1, 1, 2000, true);
                autor.InsertarRegistro(autor);

                Esperar<InvalidOperationException>(sb, "Insertar un id repetido",
                    () => autor.InsertarRegistro(autor));
                Esperar<InvalidOperationException>(sb, "Actualizar un id inexistente",
                    () => autor.ActualizarRegistro(new Autor(99, "Ana", "Lopez", "Mexicana", new DateTime(1950, 5, 20), true)));
                Esperar<InvalidOperationException>(sb, "Eliminar un id inexistente",
                    () => autor.EliminarRegistro("99"));
                Esperar<ArgumentException>(sb, "Consultar con un id que no es numero",
                    () => autor.ConsultarRegistro("abc"));
                Esperar<ArgumentNullException>(sb, "Insertar un objeto nulo",
                    () => autor.InsertarRegistro(null));
                Esperar<ArgumentException>(sb, "Insertar un objeto de otro tipo (un Libro en Autor)",
                    () => autor.InsertarRegistro(libro));
                Verificar(sb, "Consultar un id inexistente devuelve null",
                          autor.ConsultarRegistro("99") == null);

                autor.EliminarRegistro("1"); 
            }
            catch (Exception ex)
            {
                Verificar(sb, "Casos de error sin excepciones inesperadas (" + ex.GetType().Name + ": " + ex.Message + ")", false);
            }

            sb.AppendLine();
            sb.AppendLine("VALIDACIONES DE LOS MODELOS");
            Esperar<ArgumentException>(sb, "Id negativo (validacion heredada de EntidadBase)",
                () => new Autor(-1, "Ana", "Lopez", "Mexicana", new DateTime(1950, 5, 20), true));
            Esperar<ArgumentException>(sb, "Nombre vacio en Autor",
                () => new Autor(2, "", "Lopez", "Mexicana", new DateTime(1950, 5, 20), true));
            Esperar<ArgumentException>(sb, "ISBN con longitud invalida en Libro",
                () => new Libro(2, "Titulo", "123", 1, 1, 1, 2000, true));
            Esperar<ArgumentException>(sb, "Telefono con menos de 10 digitos en Usuario",
                () => new Usuario(2, "Luis", "Perez", "luis@correo.com", "123", "U-002", true));
            Esperar<ArgumentException>(sb, "Metodo de pago invalido en Pago",
                () => new Pago(2, 1, 50.0, "Cheque", true));

            sb.AppendLine();
            sb.AppendLine(new string('=', 78));
            sb.AppendLine("RESULTADO: " + correctas + " correctas, " + fallidas + " fallidas.");

            return sb.ToString();
        }

        private static void Verificar(StringBuilder sb, string descripcion, bool condicion)
        {
            if (condicion)
            {
                correctas++;
                sb.AppendLine("[OK]    " + descripcion);
            }
            else
            {
                fallidas++;
                sb.AppendLine("[FALLA] " + descripcion);
            }
        }

        private static void Esperar<T>(StringBuilder sb, string descripcion, Action accion) where T : Exception
        {
            try
            {
                accion();
                Verificar(sb, descripcion + " -> debia lanzar " + typeof(T).Name, false);
            }
            catch (Exception ex)
            {
                Verificar(sb, descripcion + " -> lanzo " + typeof(T).Name, ex.GetType() == typeof(T));
            }
        }
    }
}