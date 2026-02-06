
using System;

using System.Windows.Forms;
using Sistema.Business;

namespace Sistema.Presentation
{
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void Listar() //Method to list users
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NUsuario.Listar(), which returns all users.
                DgvListado.DataSource = NPersona.ListarProveedores(); //Call to the business layer to get the list of users
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
                DgvListado.DataSource = NPersona.BuscarProveedores(TxtBuscar.Text); //Call to the business layer to search users based on the text in TxtBuscar
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


        // Clears all input fields and resets UI controls to their default state.
        private void Limpiar()
        {
            TxtBuscar.Clear(); // Clears the search textbox.
            TxtNombre.Clear(); // Clears the name textbox.
            TxtId.Clear(); // Clears the ID textbox.
            TxtNumeroDocumento.Clear(); // Clears the document number textbox.
            TxtDireccion.Clear(); // Clears the address textbox.
            TxtTelefono.Clear(); // Clears the phone textbox.
            TxtEmail.Clear(); // Clears the email textbox.
            TxtClave.Clear(); // Clears the password textbox.



            BtnInsertar.Visible = true; // Shows the Insert button.
            BtnActualizar.Visible = false; // Hides the Update button.
            ErrorIcono.Clear(); // Clears any error icons.

            DgvListado.Columns[0].Visible = false; // Hides the selection column.
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

        private void FrmProvedor_Load(object sender, EventArgs e)
        {
            this.Listar(); // Calls the Listar method to populate the DataGridView when the form loads.
        }
    }
}
