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
    public partial class FrmCategoria : Form
    {
        // Stores the previous name of the category for update operations.
        private string NombreAnt; //Variable to store the previous name of the category

        // Constructor for the form. Initializes UI components.
        public FrmCategoria()
        {
            InitializeComponent(); // Calls the method to initialize all UI controls and events.
        }

        // Lists all categories and updates the DataGridView.
        private void Listar() //Method to list categories 
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Listar(), which returns all categories.
                DgvListado.DataSource = NCategoria.Listar(); //Call to the business layer to get the list of categories
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

        // Searches for categories based on the text in TxtBuscar.
        private void Buscar() //Method to search categories
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Buscar(), which returns matching categories.
                DgvListado.DataSource = NCategoria.Buscar(TxtBuscar.Text); //Call to the business layer to search categories based on the text in TxtBuscar
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
            DgvListado.Columns[0].Visible = false; // Hides the first column (usually ID or selection).
            DgvListado.Columns[1].Visible = false; // Hide the second column (could be internal data).
            DgvListado.Columns[2].Width = 150; // Sets the width of the third column (e.g., Name).
            DgvListado.Columns[3].Width = 400; // Sets the width of the fourth column (e.g., Description).
            DgvListado.Columns[3].HeaderText = "Descripcion"; // Sets the header text of the fourth column.
            DgvListado.Columns[4].Width = 100; // Sets the width of the fifth column (e.g., Status).
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

        // Event handler for form load event. Lists all categories when the form loads.
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Listar(); //Call to list categories when the form loads
        }

        // Event handler for search button click event. Searches for categories.
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); //Call to search categories when the search button is clicked
        }

        // Event handler for insert button click event. Inserts a new category.
        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = ""; //Variable to store the response from the business layer
                                  // Checks if the name textbox is empty.
                if (TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados"); //Show error message if name is empty
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre"); //Set error icon on the name textbox
                }
                else
                {
                    // Calls the business layer to insert a new category with the entered name and description.
                    Rpta = NCategoria.Insertar(TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim()); //Call to business layer to insert a new category
                                                                                                   // Checks if the response is OK (successful insert).
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro"); //Show success message
                        this.Limpiar(); //Clear the input fields
                        this.Listar(); //Refresh the category list
                    }
                    else
                    {
                        this.MensajeError(Rpta); //Show error message with the response from the business layer
                    }
                }
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }

        // Event handler for cancel button click event. Clears fields and returns to the main tab.
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar(); // Clears all input fields and resets UI controls.
            TabGeneral.SelectedIndex = 0; // Switches to the main tab (index 0).
        }

        // Event handler for double-clicking a row in the DataGridView.
        // Loads the selected category's data into the input fields for editing.
        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar(); // Clears all input fields and resets UI controls.
                BtnInsertar.Visible = false; // Hides the Insert button.
                BtnActualizar.Visible = true; // Shows the Update button.

                // Loads the selected category's ID, name, and description into the respective textboxes.
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value); // Stores the previous name for update validation.
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
                TabGeneral.SelectedIndex = 1; // Switches to the edit tab (index 1).
            }
            catch (Exception)
            {
                // Shows an error message if the selection fails.
                MessageBox.Show("Seleccione desde la celda nombre"); //Show error message if exception occurs
            }
        }

        // Event handler for update button click event. Updates the selected category.
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = ""; //Variable to store the response from the business layer
                                  // Checks if the name or ID textbox is empty.
                if (TxtNombre.Text == string.Empty || TxtId.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados"); //Show error message if name is empty
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre"); //Set error icon on the name textbox
                }
                else
                {
                    // Calls the business layer to update the category with the entered data.
                    Rpta = NCategoria.Actualizar(Convert.ToInt32(TxtId.Text), this.NombreAnt, TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim()); //Call to business layer to insert a new category
                                                                                                                                                  // Checks if the response is OK (successful update).
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actuliazó de forma correcta el registro"); //Show success message
                        this.Limpiar(); //Clear the input fields
                        this.Listar(); //Refresh the category list
                    }
                    else
                    {
                        this.MensajeError(Rpta); //Show error message with the response from the business layer
                    }
                }
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }

        // Event handler for the selection checkbox change event.
        // Shows or hides action buttons and selection column based on the checkbox state.
        private void ChkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccion.Checked)
            {
                DgvListado.Columns[0].Visible = true; // Shows the selection column.
                BtnActivar.Visible = true; // Shows the Activate button.
                BtnDesactivar.Visible = true; // Shows the Deactivate button.
                BtnEliminar.Visible = true; // Shows the Delete button.
            }
            else
            {
                DgvListado.Columns[0].Visible = false; // Hides the selection column.
                BtnActivar.Visible = false; // Hides the Activate button.
                BtnDesactivar.Visible = false; // Hides the Deactivate button.
                BtnEliminar.Visible = false; // Hides the Delete button.
            }
        }

        // Event handler for clicking a cell in the DataGridView.
        // Toggles the value of the selection checkbox in the clicked row.
        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Checks if the clicked column is the selection checkbox column.
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
                    "Realmente deseas eliminar esta categoria?", // Message to display
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
                            Rpta = NCategoria.Eliminar(Codigo);

                            // If the deletion was successful, show a success message with the category name.
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó correctamente el registro " + Convert.ToString(row.Cells[2].Value));
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

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                // Show a confirmation dialog to the user before deleting categories.
                // The dialog displays a question icon and OK/Cancel buttons.
                Opcion = MessageBox.Show(
                    "Realmente deseas activar esta categoria?", // Message to display
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
                            Rpta = NCategoria.Activar(Codigo);

                            // If the deletion was successful, show a success message with the category name.
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se activo correctamente el registro " + Convert.ToString(row.Cells[2].Value));
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

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                // Show a confirmation dialog to the user before deleting categories.
                // The dialog displays a question icon and OK/Cancel buttons.
                Opcion = MessageBox.Show(
                    "Realmente deseas Desactivar esta categoria?", // Message to display
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
                            Rpta = NCategoria.Desactivar(Codigo);

                            // If the deletion was successful, show a success message with the category name.
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se desactivo correctamente el registro " + Convert.ToString(row.Cells[2].Value));
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
