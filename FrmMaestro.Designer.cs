// Actividad 3.5 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public partial class FrmMaestro : Form
    {
        private IPanelCRUD vistaActiva;
        private MenuPersona3 menuModulos;
        private GuiaPersona3 guia;
        private Menup btnHamburguesa;
        private EscaladorUI escalador;
        private FondoSubmarino fondoSubmarino;

        // MDI
        private MdiClient areaMdi;
        private MenuStrip msPrincipal;
        private ToolStripMenuItem mnuVentana;
        private ToolStripMenuItem mnuCascada;
        private ToolStripMenuItem mnuMosaicoVertical;
        private ToolStripMenuItem mnuMosaicoHorizontal;
        private ToolStripMenuItem mnuProcesos;
        private ToolStripMenuItem mnuReporteMasivo;
        private ToolStripStatusLabel tsslCreditos;

        private readonly string[] modulos =
        {
            "Administrador", "Autor", "Categoria", "Editorial", "Ejemplar",
            "Libro", "Pago", "Prestamo", "Sancion", "Usuario"
        };

        public FrmMaestro()
        {
            InitializeComponent();

            // La validación de un campo no debe impedir cerrar ventanas ni el programa
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            // ---- Paso 2: el formulario maestro es contenedor MDI ----
            this.IsMdiContainer = true;
            foreach (Control c in Controls)
            {
                if (c is MdiClient)
                {
                    areaMdi = (MdiClient)c;
                    break;
                }
            }

            // El panel que antes contenía las vistas ya no se usa (taparía el área MDI)
            pnlContenedorVistas.Visible = false;

            TemaPersona3.Aplicar(this);
            fondoSubmarino = new FondoSubmarino(this);

            // El área MDI muestra el mismo fondo animado del agua
            if (areaMdi != null)
                fondoSubmarino.CubrirMdi(areaMdi);

            cmbModulo.Items.AddRange(modulos);
            ConfigurarMenuLateral();
            ConfigurarHamburguesa();
            ConfigurarGuia();
            ConectarFondo();
            ConfigurarMenuVentana();
            ConfigurarCreditos();
            OrdenarAcople();

            this.MdiChildActivate += FrmMaestro_MdiChildActivate;

            Load += (s, e) =>
            {
                AcomodarGuia();

                escalador = EscaladorUI.Aplicar(this);

                // El menú sigue el zoom de la ventana
                escalador.EscalaCambio += (s2, e2) => menuModulos.FactorEscala = escalador.Escala;
                menuModulos.FactorEscala = escalador.Escala;
            };
        }

        // Los controles transparentes toman su fondo de aquí
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (fondoSubmarino != null)
                fondoSubmarino.PintarFondo(e.Graphics, e.ClipRectangle);
            else
                base.OnPaintBackground(e);
        }

        private void ConfigurarMenuLateral()
        {
            // Ventana más ancha para que quepa el menú
            ClientSize = new Size(1080, 600);

            // El ComboBox se conserva (oculto) para no tocar la lógica de abrir módulos
            cmbModulo.Visible = false;
            lblModulo.Visible = false;

            // El buscador y los botones Guardar / Actualizar / Eliminar viven en cada módulo.
            lblIdBusqueda.Visible = false;
            txtIdBusqueda.Visible = false;
            btnMasterBuscar.Visible = false;
            pnlInferior.Visible = false;

            menuModulos = new MenuPersona3
            {
                Dock = DockStyle.Left,
                Width = 230,
                Items = modulos
            };

            // Al elegir en el menú, se elige el mismo módulo en el ComboBox oculto
            menuModulos.SelectedIndexChanged += (s, e) =>
            {
                if (menuModulos.SelectedIndex >= 0)
                    cmbModulo.SelectedIndex = menuModulos.SelectedIndex;
            };

            Controls.Add(menuModulos);
        }

        private void ConfigurarHamburguesa()
        {
            btnHamburguesa = new Menup
            {
                Location = new Point(12, 8),
                Abierto = true
            };

            // Un clic abre o cierra el menú lateral
            btnHamburguesa.Click += (s, e) =>
            {
                menuModulos.Alternar();
                btnHamburguesa.Abierto = menuModulos.Expandido;
            };

            pnlSuperior.Controls.Add(btnHamburguesa);
        }

        private void ConfigurarGuia()
        {
            guia = new GuiaPersona3
            {
                Text = "¿Qué módulo deseas usar?",
                Size = new Size(420, 44)
            };

            pnlSuperior.Controls.Add(guia);
        }

        // El menú lateral y la barra superior pintan su propio trozo de agua
        private void ConectarFondo()
        {
            fondoSubmarino.Registrar(menuModulos);
            fondoSubmarino.Registrar(pnlSuperior);

            menuModulos.FondoExterno = (g, c) => fondoSubmarino.PintarEnControl(g, c);

            pnlSuperior.Paint += (s, e) =>
            {
                fondoSubmarino.PintarEnControl(e.Graphics, pnlSuperior);

                // El mismo tinte oscuro tenue que le pone el tema a los paneles
                using (var tinte = new SolidBrush(Color.FromArgb(90, 10, 17, 40)))
                {
                    e.Graphics.FillRectangle(tinte, pnlSuperior.ClientRectangle);
                }
            };
        }

        private void AcomodarGuia()
        {
            guia.Left = pnlSuperior.ClientSize.Width - guia.Width - 12;
            guia.Top = 6;
            guia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        // ---- Paso 5: MenuStrip con el menú "Ventana" ----
        private void ConfigurarMenuVentana()
        {
            msPrincipal = new MenuStrip();
            mnuProcesos = new ToolStripMenuItem("Procesos");
            mnuReporteMasivo = new ToolStripMenuItem("Reporte masivo de sanciones...");
            mnuVentana = new ToolStripMenuItem("Ventana");
            mnuCascada = new ToolStripMenuItem("Cascada");
            mnuMosaicoVertical = new ToolStripMenuItem("Mosaico vertical");
            mnuMosaicoHorizontal = new ToolStripMenuItem("Mosaico horizontal");

            mnuVentana.DropDownItems.Add(mnuCascada);
            mnuVentana.DropDownItems.Add(mnuMosaicoVertical);
            mnuVentana.DropDownItems.Add(mnuMosaicoHorizontal);
            mnuProcesos.DropDownItems.Add(mnuReporteMasivo);
            msPrincipal.Items.Add(mnuProcesos);
            msPrincipal.Items.Add(mnuVentana);

            // C# lista solo los formularios hijos abiertos en este menú
            msPrincipal.MdiWindowListItem = mnuVentana;
            this.MainMenuStrip = msPrincipal;

            mnuCascada.Click += mnuCascada_Click;
            mnuMosaicoVertical.Click += mnuMosaicoVertical_Click;
            mnuMosaicoHorizontal.Click += mnuMosaicoHorizontal_Click;
            mnuReporteMasivo.Click += mnuReporteMasivo_Click;

            // Colores oscuros acordes al tema
            Color fondo = Color.FromArgb(8, 24, 60);
            msPrincipal.BackColor = fondo;
            msPrincipal.ForeColor = Color.White;
            mnuVentana.DropDown.BackColor = fondo;
            mnuVentana.DropDown.ForeColor = Color.White;
            mnuProcesos.DropDown.BackColor = fondo;
            mnuProcesos.DropDown.ForeColor = Color.White;

            msPrincipal.Dock = DockStyle.Top;
            Controls.Add(msPrincipal);
        }

        // Los créditos antes estaban en el panel oculto; ahora van en la barra de estado
        private void ConfigurarCreditos()
        {
            tsslCreditos = new ToolStripStatusLabel
            {
                Alignment = ToolStripItemAlignment.Right,
                ForeColor = Color.White,
                Text = string.Join("  |  ", label1.Text, label2.Text, label3.Text, label4.Text)
            };
            statusStrip1.Items.Add(tsslCreditos);
        }

        // Orden de acople: lo que va en los bordes se acomoda primero y el área MDI ocupa el resto
        private void OrdenarAcople()
        {
            menuModulos.SendToBack();
            statusStrip1.SendToBack();
            pnlSuperior.SendToBack();
            msPrincipal.SendToBack();

            if (areaMdi != null)
                areaMdi.BringToFront();
        }

        // ---- Actividad 3.4: proceso concurrente (hilos de ejecución) ----
        private void mnuReporteMasivo_Click(object sender, EventArgs e)
        {
            AbrirReporteMasivo();
        }

        // Misma regla de instancia única que los módulos: si ya está abierto, solo se activa
        private void AbrirReporteMasivo()
        {
            foreach (Form abierto in this.MdiChildren)
            {
                if (abierto is FrmReporteMasivo)
                {
                    if (abierto.WindowState == FormWindowState.Minimized)
                    {
                        abierto.WindowState = FormWindowState.Normal;
                    }
                    abierto.Activate();
                    return;
                }
            }

            FrmReporteMasivo vista = new FrmReporteMasivo();

            TemaPersona3.Aplicar(vista);
            vista.AutoValidate = AutoValidate.EnableAllowFocusChange;

            if (areaMdi != null)
            {
                int desfase = (this.MdiChildren.Length % 4) * 25;
                vista.StartPosition = FormStartPosition.Manual;
                vista.Size = new Size(areaMdi.ClientSize.Width * 85 / 100, areaMdi.ClientSize.Height * 85 / 100);
                vista.Location = new Point(10 + desfase, 10 + desfase);
            }

            vista.MdiParent = this;
            vista.Show();

            tsslEstado.Text = "Proceso activo: Reporte masivo de sanciones";
        }

        private void mnuCascada_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuMosaicoVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuMosaicoHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        // La vista activa es siempre la ventana hija que tiene el foco
        private void FrmMaestro_MdiChildActivate(object sender, EventArgs e)
        {
            vistaActiva = this.ActiveMdiChild as IPanelCRUD;

            if (vistaActiva == null)
            {
                guia.Text = "¿Qué módulo deseas usar?";
                tsslEstado.Text = "Primero elige un módulo.";
            }
        }

        // Nombre del módulo en mayúsculas y con acentos, para el título gigante
        private static string TituloPara(string modulo)
        {
            switch (modulo)
            {
                case "Categoria":
                    return "CATEGORÍA";
                case "Prestamo":
                    return "PRÉSTAMO";
                case "Sancion":
                    return "SANCIÓN";
                default:
                    return modulo == null ? "" : modulo.ToUpper();
            }
        }

        // Nombre del módulo con acentos, para el texto guía
        private static string NombrePara(string modulo)
        {
            switch (modulo)
            {
                case "Categoria":
                    return "Categoría";
                case "Prestamo":
                    return "Préstamo";
                case "Sancion":
                    return "Sanción";
                default:
                    return modulo ?? "";
            }
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbrirModulo(cmbModulo.SelectedItem?.ToString());
        }

        // Tipo de formulario de cada módulo (para revisar si ya está abierto)
        private Type TipoPara(string modulo)
        {
            switch (modulo)
            {
                case "Administrador":
                    return typeof(FrmAdministrador);
                case "Autor":
                    return typeof(FrmAutor);
                case "Categoria":
                    return typeof(FrmCategoria);
                case "Editorial":
                    return typeof(FrmEditorialcs);
                case "Ejemplar":
                    return typeof(FrmEjemplar);
                case "Libro":
                    return typeof(FrmLibro);
                case "Pago":
                    return typeof(FrmPago);
                case "Prestamo":
                    return typeof(FrmPrestamo);
                case "Sancion":
                    return typeof(FrmSancion);
                case "Usuario":
                    return typeof(FrmUsuario);
                default:
                    return null;
            }
        }

        private Form CrearVista(string modulo)
        {
            switch (modulo)
            {
                case "Administrador":
                    return new FrmAdministrador();
                case "Autor":
                    return new FrmAutor();
                case "Categoria":
                    return new FrmCategoria();
                case "Editorial":
                    return new FrmEditorialcs();
                case "Ejemplar":
                    return new FrmEjemplar();
                case "Libro":
                    return new FrmLibro();
                case "Pago":
                    return new FrmPago();
                case "Prestamo":
                    return new FrmPrestamo();
                case "Sancion":
                    return new FrmSancion();
                case "Usuario":
                    return new FrmUsuario();
                default:
                    return null;
            }
        }

        // ---- Paso 4: algoritmo de instancia única ----
        private void AbrirModulo(string modulo)
        {
            Type tipo = TipoPara(modulo);
            if (tipo == null)
                return;

            foreach (Form abierto in this.MdiChildren)
            {
                if (abierto.GetType() == tipo)
                {
                    if (abierto.WindowState == FormWindowState.Minimized)
                    {
                        abierto.WindowState = FormWindowState.Normal;
                    }
                    abierto.Activate();
                    return;
                }
            }

            Form vista = CrearVista(modulo);
            if (vista == null)
                return;

            MostrarVista(vista, modulo);
        }

        private void MostrarVista(Form vista, string modulo)
        {
            // Barra con buscador y botones propios del módulo (antes de aplicar el tema, para que la estilice)
            BarraAccionesPersona3.Agregar(vista, errorProvider1, statusStrip1);

            // Aplicar el tema azul, la escena lejana y el título gigante al módulo
            TemaPersona3.Aplicar(vista);
            FondoModulo.Aplicar(vista, TituloPara(modulo));

            vista.Text = NombrePara(modulo);

            // Permite cerrar la ventana aunque algún campo no haya pasado su validación
            vista.AutoValidate = AutoValidate.EnableAllowFocusChange;

            // Tamaño inicial: siempre cabe completo dentro del área de trabajo
            if (areaMdi != null)
            {
                int desfase = (this.MdiChildren.Length % 4) * 25;
                int ancho = areaMdi.ClientSize.Width * 75 / 100;
                int alto = areaMdi.ClientSize.Height * 75 / 100;

                vista.StartPosition = FormStartPosition.Manual;
                vista.Size = new Size(ancho, alto);
                vista.Location = new Point(10 + desfase, 10 + desfase);
            }

            // ---- Paso 3: ventana hija del maestro ----
            vista.MdiParent = this;
            vista.Show();

            // Se reafirma después de mostrarla, por si el formulario hijo lo cambió al cargarse
            vista.AutoValidate = AutoValidate.EnableAllowFocusChange;

            // Se reafirma la posición después de mostrarla (el MDI a veces la reacomoda)
            if (areaMdi != null)
            {
                int desfase = ((this.MdiChildren.Length - 1) % 4) * 25;
                vista.Location = new Point(10 + desfase, 10 + desfase);
            }

            // El contenido del módulo hace zoom para ocupar el espacio disponible
            EscaladorModulo.Aplicar(vista);

            vistaActiva = vista as IPanelCRUD;

            errorProvider1.Clear();
            tsslEstado.Text = "Módulo activo: " + modulo;
            guia.Text = "¿Qué deseas hacer en " + NombrePara(modulo) + "?";
        }

        // ---------- Botones maestros (ocultos; la lógica ahora la llama la barra de cada módulo) ----------
        private void btnMasterGuardar_Click(object sender, EventArgs e)
        {
            if (!HayVistaActiva()) return;
            vistaActiva.EjecutarGuardar();
        }

        private void btnMasterBuscar_Click(object sender, EventArgs e)
        {
            if (!HayVistaActiva()) return;
            vistaActiva.EjecutarBuscar(txtIdBusqueda.Text, errorProvider1);
        }

        private void btnMasterActualizar_Click(object sender, EventArgs e)
        {
            if (!HayVistaActiva()) return;
            vistaActiva.EjecutarActualizar();
        }

        private void btnMasterEliminar_Click(object sender, EventArgs e)
        {
            if (!HayVistaActiva()) return;
            vistaActiva.EjecutarEliminar(statusStrip1);
        }

        private bool HayVistaActiva()
        {
            if (vistaActiva == null)
            {
                tsslEstado.Text = "Primero elige un módulo.";
                return false;
            }
            return true;
        }

        private void txtIdBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}