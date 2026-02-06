using Sistema.Business;
using System;

using System.Windows.Forms;
using System.Data;
using Sistema.Buisiness;


namespace Sistema.Presentation
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void Listar() //Method to list users
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NUsuario.Listar(), which returns all users.
                DgvListado.DataSource = NUsuario.Listar(); //Call to the business layer to get the list of users
                this.Limpiar(); // Clears all input fields and resets UI controls.
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

        // Searches for users based on the text in TxtBuscar.
        private void Buscar() //Method to search users
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NUsuario.Buscar(), which returns matching users.
                DgvListado.DataSource = NUsuario.Buscar(TxtBuscar.Text); //Call to the business layer to search users based on the text in TxtBuscar
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
            DgvListado.Columns[2].Visible = false; // Hides the third column (Password).
            DgvListado.Columns[1].Width = 50; // Sets the width of the second column (Name).
            DgvListado.Columns[3].Width = 100; // Sets the width of the fourth column (Email).
            DgvListado.Columns[4].Width = 170; // Sets the width of the fifth column (Phone).
            DgvListado.Columns[5].Width = 100; // Sets the width of the sixth column (Address).
            DgvListado.Columns[5].HeaderText = "Documento"; // Sets the header text of the sixth column to "Documento".
            DgvListado.Columns[6].Width = 100; // Sets the width of the seventh column (Document Number).
            DgvListado.Columns[6].HeaderText = "Número Documento"; // Sets the header text of the seventh column to "Número Documento".
            DgvListado.Columns[7].Width = 120; 
            DgvListado.Columns[7].HeaderText = "Direccion"; // Sets the header text of the eighth column to "Direccion".
            DgvListado.Columns[8].Width = 100; 
            DgvListado.Columns[8].HeaderText = "Telefono"; // Sets the header text of the ninth column to "Rol".
            DgvListado.Columns[9].Width = 120;
        }
       

        // Clears all input fields and resets UI controls to their default state.
        private void Limpiar()
        {
            TxtBuscar.Clear(); // Clears the search textbox.
            TxtNombre.Clear(); // Clears the name textbox.
            TxtDescripcion.Clear(); // Clears the description textbox.
            TxtId.Clear(); // Clears the ID textbox.
            BtnInsertar.Visible = true; // Shows the Insert button.
            BtnActualizar.Visible = false; // Hides the Update button.
            ErrorIcono.Clear(); // Clears any error icons.

            DgvListado.Columns[0].Visible = false; // Hides the selection column.
            BtnActivar.Visible = false; // Hides the Activate button.
            BtnDesactivar.Visible = false; // Hides the Deactivate button.
            BtnEliminar.Visible = false; // Hides the Delete button.
            ChkSeleccion.Checked = false; // Unchecks the selection checkbox.
        }

        // Shows an error message box with a custom message.
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Shows an information message box with a custom message.
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar(); // When the form loads, call the Listar method to populate the DataGridView with users.
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); // When the search button is clicked, call the Buscar method to search for users based on the text in TxtBuscar.

        }
    }
}
