using Sistema.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Buisiness;

namespace Sistema.Presentation
{
    public partial class FrmIngreso : Form
    {

        private DataTable DtDetalle = new DataTable();
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void Listar() //Method to list categories 
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Listar(), which returns all categories.
                DgvListado.DataSource = NIngreso.Listar(); //Call to the business layer to get the list of categories
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
                DgvListado.DataSource = NIngreso.Buscar(TxtBuscar.Text); //Call to the business layer to search categories based on the text in TxtBuscar
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
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[0].Width = 100; // Sets the width of the first column (e.g., ID).
            DgvListado.Columns[3].Width = 150; // Sets the width of the second column (e.g., Code).
            DgvListado.Columns[4].Width = 150; // Sets the width of the third column (e.g., Name).
            DgvListado.Columns[5].Width = 100; // Sets the width of the fourth column (e.g., Status).
            DgvListado.Columns[5].HeaderText = "Documento"; // Sets the header text of the fourth column.
            DgvListado.Columns[6].Width = 70; // Sets the width of the fifth column (e.g., Description).
            DgvListado.Columns[6].HeaderText = "Serie"; // Sets the header text of the fifth column.
            DgvListado.Columns[7].Width = 70; // Sets the width of the sixth column (e.g., Description).
            DgvListado.Columns[7].HeaderText = "Número"; // Sets the header text of the sixth column.
            DgvListado.Columns[8].Width = 60; // Sets the width of the seventh column (e.g., Description).
            DgvListado.Columns[9].Width = 100; // Sets the width of the eighth column (e.g., Description).
            DgvListado.Columns[10].Width = 100; // Sets the width of the ninth column (e.g., Description).
            DgvListado.Columns[11].Width = 100; // Sets the width of the tenth column (e.g., Description).
        }

        // Clears all input fields and resets UI controls to their default state.
        private void Limpiar()
        {
            TxtBuscar.Clear(); // Clears the search textbox.
            TxtId.Clear(); // Clears the ID textbox.
            BtnInsertar.Visible = true; // Shows the Insert button.
          
            ErrorIcono.Clear(); // Clears any error icons.

            DgvListado.Columns[0].Visible = false; // Hides the selection column.
            BtnAnular.Visible = false; // Hides the Activate button.         
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


        private void CreateTable() //Method to create a DataTable for details (not fully implemented in the provided code)
        {
            // This method is intended to create a DataTable with specific columns for details.
            // The actual implementation is not provided in the code snippet, but it would typically involve:
            // - Creating a new DataTable instance.
            // - Adding DataColumn objects to the DataTable for each required column (e.g., IdDetalleIngreso, IdArticulo, etc.).
            // - Returning the configured DataTable for use in other parts of the form (e.g., when inserting a new record).
        
          this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32")); // Adds a column for article ID of type integer.
          this.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String")); // Adds a column for article code of type string.
          this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String")); // Adds a column for article name of type string.
          this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32")); // Adds a column for quantity of type integer.
          this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal")); // Adds a column for purchase price of type decimal.
          this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal")); // Adds a column for subtotal of type decimal.


          DgvDetalle.DataSource = this.DtDetalle; // Sets the DataSource of DgvDetalle to the DtDetalle DataTable, allowing it to display the details data.

            DgvDetalle.Columns[0].Visible = false; // Hides the first column (IdDetalleIngreso) as it is typically an internal identifier not needed for display.
            DgvDetalle.Columns[1].HeaderText = "CODIGO"; // Sets the header text of the second column to "Código".
            DgvDetalle.Columns[1].Width = 100; // Sets the width of the second column to 100 pixels.
            DgvDetalle.Columns[2].HeaderText = "ARTICULO"; // Sets the header text of the third column to "Artículo".
            DgvDetalle.Columns[2].Width = 200; // Sets the width of the third column to 200 pixels.
            DgvDetalle.Columns[3].HeaderText = "CANTIDAD"; // Sets the header text of the fourth column to "Cantidad".
            DgvDetalle.Columns[3].Width = 70; // Sets the width of the fourth column to 70 pixels.
            DgvDetalle.Columns[4].HeaderText = "PRECIO"; // Sets the header text of the fifth column to "Precio Compra".
            DgvDetalle.Columns[4].Width = 70; // Sets the width of the fifth column to 90 pixels.
            DgvDetalle.Columns[5].HeaderText = "IMPORTE"; // Sets the header text of the sixth column to "Importe".
            DgvDetalle.Columns[5].Width = 80; // Sets the width of the sixth column to 90 pixels.


            DgvDetalle.Columns[1].ReadOnly = true; // Sets the second column (Código) to read-only, preventing user edits.
            DgvDetalle.Columns[2].ReadOnly = true; // Sets the third column (Artículo) to read-only, preventing user edits.
            DgvDetalle.Columns[5].ReadOnly = true; // Sets the sixth column (Importe) to read-only, preventing user edits as it is typically calculated from quantity and price.
        }



        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Listar(); // Calls the Buscar method to populate the DataGridView when the form loads.
            this.CreateTable(); // Calls the CreateTable method to set up the details DataTable and configure the DgvDetalle DataGridView when the form loads.
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); // Calls the Buscar method to search for categories based on the text in TxtBuscar when the search button is clicked.
        }

        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVista_ProveedorIngreso vista = new FrmVista_ProveedorIngreso(); // Creates a new instance of the FrmVista_ProveedorIngreso form, which is likely a form that allows the user to search for and select a supplier.
            vista.ShowDialog(); // Displays the FrmVista_ProveedorIngreso form as a modal dialog, allowing the user to interact with it and select a supplier before returning to the main form.
            TxtIdProveedor.Text = Convert.ToString(Variables.IdProveedor);
            TxtNombreProveedor.Text = Variables.NombreProveedor;
        }
    }
}
