using Sistema.Business;
using System;

using System.Windows.Forms;

namespace Sistema.Presentation
{
    public partial class FrmVista_ProveedorIngreso : Form
    {
        public FrmVista_ProveedorIngreso()
        {
            InitializeComponent();
        }

        private void Listar() //Method to list categories 
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Listar(), which returns all categories.
                DgvListado.DataSource = NPersona.ListarProveedores(); //Call to the business layer to get the list of categories
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

        // Searches for categories based on the text in TxtBuscar.
        private void Buscar() //Method to search categories
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Buscar(), which returns matching categories.
                DgvListado.DataSource = NPersona.BuscarProveedores(TxtBuscar.Text); //Call to the business layer to search categories based on the text in TxtBuscar
                this.Formato(); // Formats the DataGridView columns.
                                // Updates the label to show the total number of records found.
                LblTotal.Text = "Total registro: " + Convert.ToString(DgvListado.Rows.Count); //Display total number of records found
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }

        // Formats the DataGridView columns (visibility, width, header text).
        private void Formato()
        {
            DgvListado.Columns[0].Visible = false; // Hides the first column (ID).
            DgvListado.Columns[1].Width = 50; // Sets the width of the second column (Name).
            DgvListado.Columns[2].Width = 100; // Sets the width of the second column (Name).
            DgvListado.Columns[2].HeaderText = "Tipo Persona"; // Sets the header text of the third column to "Tipo Documento".
            DgvListado.Columns[3].Width = 170; // Sets the width of the fourth column (Email).
            DgvListado.Columns[4].Width = 100; // Sets the width of the fifth column (Phone).
            DgvListado.Columns[4].HeaderText = "Documento"; // Sets the header text of the sixth column to "Documento".
            DgvListado.Columns[5].Width = 150; // Sets the width of the seventh column (Document Number).
            DgvListado.Columns[5].HeaderText = "Número Documento"; // Sets the header text of the seventh column to "Número Documento".
            DgvListado.Columns[6].Width = 120;
            DgvListado.Columns[6].HeaderText = "Direccion"; // Sets the header text of the eighth column to "Direccion".
            DgvListado.Columns[7].Width = 100;
            DgvListado.Columns[7].HeaderText = "Telefono"; // Sets the header text of the ninth column to "Rol".
            DgvListado.Columns[8].Width = 120;
        }

        private void FrmVista_ProveedorIngreso_Load(object sender, EventArgs e)
        {

            // In order to save memory, do not load the list of providers when the form loads. The list will be loaded when the user clicks the search button.
            this.Listar(); // Calls the Listar method to populate the DataGridView when the form loads
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); // Calls the Buscar method to search for records based on the text in TxtBuscar when the search button is clicked
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.IdProveedor = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);  // Assuming "ID" is the name of the column that contains the provider's ID
            Variables.NombreProveedor = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value); // Assuming "Nombre" is the name of the column that contains the provider's name
            this.Close(); // Closes the form after setting the selected provider's ID and name in the Variables class
        }
    }
}
