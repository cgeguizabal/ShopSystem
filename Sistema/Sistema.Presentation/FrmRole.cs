
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Business;



namespace Sistema.Presentation
{
    public partial class FrmRole : Form
    {
        public FrmRole()
        {
            InitializeComponent();
        }

        // Lists all categories and updates the DataGridView.
        private void Listar() //Method to list categories 
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Listar(), which returns all categories.
                DgvListado.DataSource = NRole.Listar(); //Call to the business layer to get the list of categories
                this.Formato(); // Formats the DataGridView columns (width, visibility, headers).
                                // Updates the label to show the total number of records in the DataGridView.
                LblTotal.Text = "Total registro: " + Convert.ToString(DgvListado.Rows.Count); //Display total number of records
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[0].HeaderText = "ID";
            DgvListado.Columns[1].Width = 200;
            DgvListado.Columns[1].HeaderText = "Nombre";
        }

        private void FrmRole_Load(object sender, EventArgs e)
        {
            this.Listar(); // When the form loads, call the Listar method to populate the DataGridView with categories.
        }
    }
}
