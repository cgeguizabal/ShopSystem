using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentation
{
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;
        public int Idusuario;
        public int IdRol;
        public string Nombre;
        public string Rol;
        public bool Estado;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.MdiParent = this;
            frm.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulo frm = new FrmArticulo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRole frm = new FrmRole();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            StBarraInferior.Text = "Usuario: " + this.Nombre + " - Rol: " + this.Rol; // Displays the user's name and role in the status bar when the main form loads
            MessageBox.Show("Bienvenido al Sistema, " + this.Nombre + "!", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information); // Displays a welcome message to the user when the main form loads

            if (this.Rol.Equals("Administrador"))
            {
                // If the user is an administrator, show all menu items.
                MnuAlmacen.Enabled = true; // Show the "Almacen" menu item for administrators
                MnuIngresos.Enabled = true; // Show the "Ingresos" menu item for administrators
                MnuVentas.Enabled = true; // Show the "Ventas" menu item for administrators
                MnuAccesos.Enabled = true; // Show the "Accesos" menu item for administrators
                MnuConsultas.Enabled = true; // Show the "Consultas" menu item for administrators
                TsCompras.Enabled = true; // Show the "Compras" toolbar button for administrators
                TsVentas.Enabled = true; // Show the "Ventas" toolbar button for administrators
            }
            else if (this.Rol.Equals("Vendedor"))
            {
                // If the user is a seller, show only the categories and articles menu items.
                MnuAlmacen.Enabled = true; // Show the "Almacen" menu item for administrators
                MnuIngresos.Enabled = true; // Show the "Ingresos" menu item for administrators
                MnuVentas.Enabled = true; // Show the "Ventas" menu item for administrators
                MnuAccesos.Enabled = false; // Show the "Accesos" menu item for administrators
                MnuConsultas.Enabled = true; // Show the "Consultas" menu item for administrators
                TsCompras.Enabled = true; // Show the "Compras" toolbar button for administrators
                TsVentas.Enabled = true;

            } else if (this.Rol.Equals("Almacenero"))
            {
                // If the user is a warehouse manager, show only the categories and articles menu items.
                MnuAlmacen.Enabled = false; // Show the "Almacen" menu item for administrators
                MnuIngresos.Enabled = false; // Show the "Ingresos" menu item for administrators
                MnuVentas.Enabled = false; // Show the "Ventas" menu item for administrators
                MnuAccesos.Enabled = false; // Show the "Accesos" menu item for administrators
                MnuConsultas.Enabled = false; // Show the "Consultas" menu item for administrators
                TsCompras.Enabled = false; // Show the "Compras" toolbar button for administrators
                TsVentas.Enabled = false;
            }

            }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Ensures the entire application exits when the main form is closed
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea salir del sistema?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void provedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new FrmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngreso frm = new FrmIngreso();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
