
using Sistema.Buisiness;
using Sistema.Business;
using System;
using System.Windows.Forms;

namespace Sistema.Presentation
{
    public partial class FrmProveedor : Form
    {

        private string NombreAnt; // Variable to store the previous name of the user for update operations.
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Example validation (add more as needed)
                if (string.IsNullOrWhiteSpace(TxtNombre.Text))
                {
                    this.MensajeError("Faltan ingresar algunos datos, serán remarcados."); // Show error if any required field is missing                  
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");



                    // Call the business layer to insert the user
                    string rpta = NPersona.Insertar(
                        "Proveedor",
                        TxtNombre.Text.Trim(),
                        CboTipoDocumento.Text.Trim(),
                        TxtNumeroDocumento.Text.Trim(),
                        TxtDireccion.Text.Trim(),
                        TxtTelefono.Text.Trim(),
                        TxtEmail.Text.Trim()
                    );

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Usuario insertado correctamente.");
                        this.Listar();
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnInsertar.Visible = false;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                CboTipoDocumento.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
                TxtNumeroDocumento.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Num_Documento"].Value);
                TxtDireccion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Direccion"].Value);
                TxtTelefono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Telefono"].Value);
                TxtEmail.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Email"].Value);
                TabGeneral.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Example validation (add more as needed)
                if (TxtId.Text == string.Empty || string.IsNullOrWhiteSpace(TxtNombre.Text))
                {
                    this.MensajeError("Faltan ingresar algunos datos, serán remarcados."); // Show error if any required field is missing                  
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");



                    // Call the business layer to insert the user
                    string rpta = NPersona.Actualizar(
                        Convert.ToInt32(TxtId.Text),
                        "Proveedor",
                        this.NombreAnt,
                        TxtNombre.Text.Trim(),
                        CboTipoDocumento.Text.Trim(),
                        TxtNumeroDocumento.Text.Trim(),
                        TxtDireccion.Text.Trim(),
                        TxtTelefono.Text.Trim(),
                        TxtEmail.Text.Trim()
                    );

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("El provedor ha sido actualizado correctamente.");
                        this.Listar();
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }

        private void ChkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccion.Checked)
            {
                DgvListado.Columns[0].Visible = true; // Shows the selection column.
                
                BtnEliminar.Visible = true; // Shows the Delete button.
            }
            else
            {
                DgvListado.Columns[0].Visible = false; // Hides the selection column.
                
                BtnEliminar.Visible = false; // Hides the Delete button.
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                // Toggles the checkbox value for the clicked row.
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                // Show a confirmation dialog to the user before deleting categories.
                // The dialog displays a question icon and OK/Cancel buttons.
                Opcion = MessageBox.Show(
                    "Realmente deseas eliminar este Usuario?", // Message to display
                    "Sistema de Ventas",                        // Title of the dialog window
                    MessageBoxButtons.OKCancel,                 // Show OK and Cancel buttons
                    MessageBoxIcon.Question                     // Show a question icon
                );

                // If the user clicks OK, proceed with deletion.
                if (Opcion == DialogResult.OK)
                {
                    int Codigo; // Variable to store the category ID to delete
                    string Rpta = ""; // Variable to store the response from the business layer

                    // Iterate through all rows in the DataGridView.
                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        // Check if the selection checkbox is checked for this row.
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            // Get the category ID from the second column (index 1).
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            // Call the business layer to delete the category by ID.
                            Rpta = NPersona.Eliminar(Codigo);

                            // If the deletion was successful, show a success message with the category name.
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó correctamente el registro " + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                // If there was an error, show the error message.
                                this.MensajeError(Rpta);
                            }
                        }
                    }

                    // Refresh the category list after deletion.
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                // Show a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
