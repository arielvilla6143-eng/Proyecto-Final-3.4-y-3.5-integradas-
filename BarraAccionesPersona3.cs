//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public class BarraAccionesPersona3 : Panel
    {
        private const int AltoBarra = 56;
        private const int AltoBoton = 40;
        private const int AnchoAccion = 120;
        private const int AnchoBuscar = 96;
        private const int AnchoCaja = 110;
        private const int AnchoEtiqueta = 110;
        private const int Margen = 12;

        private readonly IPanelCRUD _modulo;
        private readonly ErrorProvider _errores;
        private readonly StatusStrip _estado;

        private readonly Label _lblBuscar;
        private readonly TextBox _txtBuscar;
        private readonly BotonPersona3 _btnBuscar;
        private readonly BotonPersona3 _btnGuardar;
        private readonly BotonPersona3 _btnActualizar;
        private readonly BotonPersona3 _btnEliminar;

        private float _escala = 1f;
        private readonly List<Font> _fuentes = new List<Font>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int AnchoBase
        {
            get
            {
                int izquierda = Margen + AnchoEtiqueta + 6 + AnchoCaja + 10 + AnchoBuscar;
                int derecha = 3 * AnchoAccion + 2 * Margen + Margen;
                return izquierda + 24 + derecha;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Escala
        {
            get { return _escala; }
            set
            {
                if (value <= 0f || Math.Abs(value - _escala) < 0.001f)
                    return;
                _escala = value;
                AplicarEscala();
            }
        }

        public static void Agregar(Form modulo, ErrorProvider errores, StatusStrip estado)
        {
            IPanelCRUD crud = modulo as IPanelCRUD;
            if (crud == null) return;

            modulo.Controls.Add(new BarraAccionesPersona3(crud, errores, estado));
        }

        private BarraAccionesPersona3(IPanelCRUD modulo, ErrorProvider errores, StatusStrip estado)
        {
            _modulo = modulo;
            _errores = errores;
            _estado = estado;

            _lblBuscar = new Label { AutoSize = true, Text = "ID a buscar:" };
            _txtBuscar = new TextBox { Width = AnchoCaja, CausesValidation = false };

            _btnBuscar = CrearBoton("Buscar", AnchoBuscar, false);
            _btnGuardar = CrearBoton("Guardar", AnchoAccion, true);
            _btnActualizar = CrearBoton("Actualizar", AnchoAccion, true);
            _btnEliminar = CrearBoton("Eliminar", AnchoAccion, false);

            Controls.AddRange(new Control[]
            {
                _lblBuscar, _txtBuscar, _btnBuscar,
                _btnGuardar, _btnActualizar, _btnEliminar
            });

            _btnBuscar.Click += btnBuscar_Click;
            _txtBuscar.KeyPress += txtBuscar_KeyPress;
            _txtBuscar.TextChanged += txtBuscar_TextChanged;
            _btnGuardar.Click += (s, e) => _modulo.EjecutarGuardar();
            _btnActualizar.Click += (s, e) => _modulo.EjecutarActualizar();
            _btnEliminar.Click += (s, e) => _modulo.EjecutarEliminar(_estado);

            Dock = DockStyle.Bottom;
            Height = AltoBarra;
        }

        // ---- Validación del campo de búsqueda ----

        // Solo dígitos y teclas de control; cualquier otra tecla se descarta con el sonido del sistema
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        // En cuanto el usuario escribe algo, se quita el aviso de error
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            _errores.SetError(_txtBuscar, "");
        }

        // El botón Buscar no ejecuta nada si el campo está vacío o no es un número
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = _txtBuscar.Text.Trim();

            if (id.Length == 0)
            {
                _errores.SetError(_txtBuscar, "Escribe el ID que deseas buscar.");
                _txtBuscar.Focus();
                return;
            }

            if (!int.TryParse(id, out _))
            {
                _errores.SetError(_txtBuscar, "El ID solo admite números.");
                _txtBuscar.SelectAll();
                _txtBuscar.Focus();
                return;
            }

            _errores.SetError(_txtBuscar, "");
            _modulo.EjecutarBuscar(id, _errores);
        }

        private static BotonPersona3 CrearBoton(string texto, int ancho, bool valida)
        {
            return new BotonPersona3
            {
                Text = texto,
                Size = new Size(ancho, AltoBoton),
                CausesValidation = valida
            };
        }

        private static int R(float valor)
        {
            return (int)Math.Round(valor);
        }

        private void AplicarEscala()
        {
            float s = _escala;

            Font fuenteEtiqueta = new Font("Segoe UI", 9F * s, FontStyle.Italic, GraphicsUnit.Point);
            Font fuenteCaja = new Font("Segoe UI", 9F * s, FontStyle.Regular, GraphicsUnit.Point);
            Font fuenteBoton = new Font("Segoe UI", 11F * s, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);

            _lblBuscar.Font = fuenteEtiqueta;
            _txtBuscar.Font = fuenteCaja;
            _btnBuscar.Font = fuenteBoton;
            _btnGuardar.Font = fuenteBoton;
            _btnActualizar.Font = fuenteBoton;
            _btnEliminar.Font = fuenteBoton;

            foreach (Font anterior in _fuentes)
            {
                anterior.Dispose();
            }
            _fuentes.Clear();
            _fuentes.Add(fuenteEtiqueta);
            _fuentes.Add(fuenteCaja);
            _fuentes.Add(fuenteBoton);

            _txtBuscar.Width = R(AnchoCaja * s);
            Height = R(AltoBarra * s);

            PerformLayout();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            if (_btnEliminar == null) return;

            float s = _escala;
            int altoBoton = R(AltoBoton * s);
            int anchoAccion = R(AnchoAccion * s);
            int anchoBuscar = R(AnchoBuscar * s);
            int margen = R(Margen * s);

            int y = (Height - altoBoton) / 2;

            int x = Width - margen - anchoAccion;
            _btnEliminar.SetBounds(x, y, anchoAccion, altoBoton);

            x -= margen + anchoAccion;
            _btnActualizar.SetBounds(x, y, anchoAccion, altoBoton);

            x -= margen + anchoAccion;
            _btnGuardar.SetBounds(x, y, anchoAccion, altoBoton);

            _lblBuscar.Location = new Point(margen, (Height - _lblBuscar.Height) / 2);
            _txtBuscar.Location = new Point(_lblBuscar.Right + R(6 * s), (Height - _txtBuscar.Height) / 2);
            _btnBuscar.SetBounds(_txtBuscar.Right + R(10 * s), y, anchoBuscar, altoBoton);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (Font f in _fuentes)
                {
                    f.Dispose();
                }
                _fuentes.Clear();
            }
            base.Dispose(disposing);
        }
    }
}