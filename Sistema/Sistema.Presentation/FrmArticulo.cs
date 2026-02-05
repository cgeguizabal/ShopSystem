using Sistema.Business;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.IO;
using System.Drawing.Imaging;


namespace Sistema.Presentation
{
    // Partial class definition for the FrmArticulo form, which is a Windows Form for managing articles/products.
    public partial class FrmArticulo : Form
    {
        // Stores the original path of the image selected by the user.
        private string RutaOrigen;
        // Stores the destination path where the image will be saved or copied.
        private string RutaDestino;
        // Directory path where images will be stored by default.
        private string Directorio = "C:\\Users\\interguia\\source\\repos\\cgeguizabal\\ShopSystem";

        private string NombreAnt;

        // Constructor for the form. Initializes all UI components and event handlers.
        public FrmArticulo()
        {
            InitializeComponent(); // Required to initialize the form and its controls.
        }

        // Lists all articles and updates the DataGridView with the results.
        private void Listar()
        {
            try
            {
                // Calls the business layer to get the list of articles and sets it as the DataSource for the DataGridView.
                DgvListado.DataSource = NArticulo.Listar();
                this.Limpiar(); // Clears all input fields and resets UI controls to their default state.
                this.Formato(); // Formats the DataGridView columns (width, visibility, headers).
                                // Updates the label to show the total number of records in the DataGridView.
                LblTotal.Text = "Total registro: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // Searches for articles based on the text in TxtBuscar and updates the DataGridView.
        private void Buscar()
        {
            try
            {
                // Calls the business layer to search for articles matching the search text.
                DgvListado.DataSource = NArticulo.Buscar(TxtBuscar.Text);
                this.Formato(); // Formats the DataGridView columns.
                                // Updates the label to show the total number of records found.
                LblTotal.Text = "Total registro: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // Configures the appearance and layout of the DataGridView columns.
        private void Formato()
        {
            DgvListado.Columns[0].Visible = false; // Hides the first column, usually an ID or selection column.
            DgvListado.Columns[2].Visible = false; // Hides the third column, possibly internal data not for display.
            DgvListado.Columns[0].Width = 100; // Sets the width of the first column (even if hidden).
            DgvListado.Columns[1].Width = 50; // Sets the width of the second column.
            DgvListado.Columns[3].Width = 100; // Sets the width of the fourth column.
            DgvListado.Columns[3].HeaderText = "Categoria"; // Sets the header text for the fourth column.
            DgvListado.Columns[4].Width = 100; // Sets the width of the fifth column.
            DgvListado.Columns[4].HeaderText = "Codigo"; // Sets the header text for the fifth column.
            DgvListado.Columns[5].Width = 150; // Sets the width of the sixth column.
            DgvListado.Columns[6].Width = 100; // Sets the width of the seventh column.
            DgvListado.Columns[6].HeaderText = "Precio Venta"; // Sets the header text for the seventh column.
            DgvListado.Columns[7].Width = 60; // Sets the width of the eighth column.
            DgvListado.Columns[8].Width = 200; // Sets the width of the ninth column.
            DgvListado.Columns[8].HeaderText = "Descripcion"; // Sets the header text for the ninth column.
            DgvListado.Columns[9].Width = 100; // Sets the width of the tenth column.
            DgvListado.Columns[10].Width = 100; // Sets the width of the eleventh column.
        }

        // Clears all input fields and resets UI controls to their default state.
        private void Limpiar()
        {
            TxtBuscar.Clear(); // Clears the search textbox.
            TxtNombre.Clear(); // Clears the name textbox.
            TxtDescripcion.Clear(); // Clears the description textbox.
            TxtId.Clear(); // Clears the ID textbox.
            TxtCodigo.Clear(); // Clears the code textbox.
            PanelCodigo.BackgroundImage = null; // Clears the barcode image.
            BtnGuardarCodigo.Enabled = true;
            TxtPrecioVenta.Clear(); // Clears the price textbox.
            TxtStock.Clear(); // Clears the stock textbox.
            TxtImagen.Clear(); // Clears the image textbox.
            PicImagen.Image = null; // Clears the image in the PictureBox.

            BtnInsertar.Visible = true; // Shows the Insert button.
            BtnActualizar.Visible = false; // Hides the Update button.
            ErrorIcono.Clear(); // Clears any error icons from previous validation.
            this.RutaDestino = ""; // Resets the destination path for the image.
            this.RutaOrigen = ""; // Resets the original path for the image.

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

        // Loads the list of categories into the ComboBox for category selection.
        private void CargarCategoria()
        {
            try
            {
                // Sets the data source of the ComboBox to the result of NCategoria.Seleccionar().
                CboCategoria.DataSource = NCategoria.Seleccionar();
                // Sets the value member (the actual value) to the category ID.
                CboCategoria.ValueMember = "IdCategoria";
                // Sets the display member (what the user sees) to the category name.
                CboCategoria.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                // Shows a message box with the error message and stack trace if an exception occurs.
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // Event handler for the form's Load event. Called when the form is first shown.
        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Listar(); // Lists all articles in the DataGridView.
            this.CargarCategoria(); // Loads categories into the ComboBox.
        }

        // Event handler for the search button click event. Initiates a search.
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); // Calls the search method to filter articles.
        }

        // Event handler for the "Load Image" button click event.
        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            // Creates a new OpenFileDialog to allow the user to select an image file.
            OpenFileDialog file = new OpenFileDialog();

            // Sets the filter to only show image files with .jpg, .jpeg, or .png extensions.
            file.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            // Shows the file dialog and checks if the user clicked OK (selected a file).
            if (file.ShowDialog() == DialogResult.OK)
            {
                // Loads the selected image file into the PictureBox control (PicImagen).
                // Image.FromFile creates an Image object from the file path provided.
                PicImagen.Image = Image.FromFile(file.FileName);

                // Extracts the file name (without the path) and sets it in the TxtImagen textbox.
                // file.FileName.LastIndexOf("\\") finds the last backslash, so Substring gets the file name only.
                TxtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);

                // Stores the full path of the selected image in the RutaOrigen variable for later use (e.g., saving or copying).
                this.RutaOrigen = file.FileName;
            }
        }

        // Event handler for the "Generate Barcode" button click event.
        // Event handler for the "Generate Barcode" button click event.
        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that the code textbox has a value
                if (string.IsNullOrWhiteSpace(TxtCodigo.Text))
                {
                    this.MensajeError("Por favor ingrese un código antes de generar el código de barras");
                    TxtCodigo.Focus();
                    return;
                }

                // Create barcode writer with ZXing
                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Width = 300,
                        Height = 100,
                        Margin = 10,
                        PureBarcode = false // Shows the text below barcode
                    }
                };

                // Generate barcode as Bitmap
                Bitmap barcodeBitmap = writer.Write(TxtCodigo.Text.Trim());

                // Dispose previous image to prevent memory leaks
                if (PanelCodigo.BackgroundImage != null)
                {
                    PanelCodigo.BackgroundImage.Dispose();
                }

                // Set the new barcode
                PanelCodigo.BackgroundImage = barcodeBitmap;
                PanelCodigo.BackgroundImageLayout = ImageLayout.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de barras: " + ex.Message,
                               "Sistema de Ventas",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        // Event handler for the "Save Barcode" button click event.
        private void BtnGuardarCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if barcode exists
                if (PanelCodigo.BackgroundImage == null)
                {
                    this.MensajeError("Primero debe generar un código de barras");
                    return;
                }

                // Clone the current barcode image
                Image imgFinal = (Image)PanelCodigo.BackgroundImage.Clone();

                // Create SaveFileDialog
                SaveFileDialog DialogGuardar = new SaveFileDialog();
                DialogGuardar.AddExtension = true;
                DialogGuardar.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                DialogGuardar.FileName = $"Barcode_{TxtCodigo.Text}"; // Default filename

                if (DialogGuardar.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(DialogGuardar.FileName))
                    {
                        // Determine format based on extension
                        ImageFormat format = ImageFormat.Png;
                        string ext = Path.GetExtension(DialogGuardar.FileName).ToLower();
                        if (ext == ".jpg" || ext == ".jpeg")
                            format = ImageFormat.Jpeg;
                        else if (ext == ".bmp")
                            format = ImageFormat.Bmp;

                        imgFinal.Save(DialogGuardar.FileName, format);
                        this.MensajeOk("Código de barras guardado correctamente");
                    }
                }

                imgFinal.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar código de barras: " + ex.Message,
                               "Sistema de Ventas",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear previous error icons from all controls.
                // This ensures that only current validation errors are shown to the user.
                ErrorIcono.Clear();

                // Boolean flag to track if all validations pass.
                // Used to determine if the form data is valid before proceeding with the insert operation.
                bool isValid = true;

                // --- CATEGORY VALIDATION ---
                // Checks if a category is selected in the ComboBox.
                // Uses SelectedValue (the actual value bound to the ComboBox) and Text (the displayed value).
                // If not selected, sets an error icon and marks validation as failed.
                if (CboCategoria.SelectedValue == null || string.IsNullOrWhiteSpace(CboCategoria.Text))
                {
                    ErrorIcono.SetError(CboCategoria, "Seleccione una categoria");
                    isValid = false;
                }

                // --- NAME VALIDATION ---
                // Checks if the name textbox is empty or contains only whitespace.
                // If empty, sets an error icon and marks validation as failed.
                if (string.IsNullOrWhiteSpace(TxtNombre.Text))
                {
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre");
                    isValid = false;
                }

                // --- PRICE VALIDATION ---
                // Checks if the price textbox is empty.
                if (string.IsNullOrWhiteSpace(TxtPrecioVenta.Text))
                {
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio de venta");
                    isValid = false;
                }
                // Uses decimal.TryParse to validate that the input is a valid decimal number and is positive.
                // This prevents runtime exceptions and ensures only valid numeric input is accepted.
                else if (!decimal.TryParse(TxtPrecioVenta.Text, out decimal precioVenta) || precioVenta < 0)
                {
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio de venta válido (número positivo)");
                    isValid = false;
                }

                // --- STOCK VALIDATION ---
                // Checks if the stock textbox is empty.
                if (string.IsNullOrWhiteSpace(TxtStock.Text))
                {
                    ErrorIcono.SetError(TxtStock, "Ingrese el stock");
                    isValid = false;
                }
                // Uses int.TryParse to validate that the input is a valid integer and is positive.
                // This prevents runtime exceptions and ensures only valid numeric input is accepted.
                else if (!int.TryParse(TxtStock.Text, out int stock) || stock < 0)
                {
                    ErrorIcono.SetError(TxtStock, "Ingrese un stock válido (número entero positivo)");
                    isValid = false;
                }

                // --- FINAL VALIDATION CHECK ---
                // If any validation failed, show a general error message and stop further execution.
                // This technique is called "fail fast": stop as soon as invalid data is detected.
                if (!isValid)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    return; // Stop execution here
                }

                // --- DATA INSERTION ---
                // All validations passed, proceed with insert.
                // Calls the business layer to insert a new article with all the validated and trimmed data.
                // Convert.ToInt32 and Convert.ToDecimal are safe here because TryParse already validated the input.
                string Rpta = NArticulo.Insertar(
                    Convert.ToInt32(CboCategoria.SelectedValue),
                    TxtCodigo.Text.Trim(),
                    TxtNombre.Text.Trim(),
                    Convert.ToDecimal(TxtPrecioVenta.Text),
                    Convert.ToInt32(TxtStock.Text),
                    TxtDescripcion.Text.Trim(),
                    TxtImagen.Text.Trim()
                );

                // --- RESPONSE HANDLING ---
                // Check if the insert was successful by comparing the response string.
                if (Rpta.Equals("OK"))
                {
                    this.MensajeOk("Se insertó de forma correcta el registro");

                    // --- IMAGE FILE HANDLING ---
                    // If an image was selected and the original path is set, copy the image to the destination directory.
                    // This ensures that the image is stored in the application's managed directory.
                    if (!string.IsNullOrWhiteSpace(TxtImagen.Text) && !string.IsNullOrWhiteSpace(this.RutaOrigen))
                    {
                        try
                        {
                            // Set the destination path using Path.Combine for proper path handling.
                            // This avoids issues with missing or extra path separators.
                            this.RutaDestino = Path.Combine(this.Directorio,  TxtImagen.Text);

                            // Check if source file exists before attempting to copy.
                            if (File.Exists(this.RutaOrigen))
                            {
                                // Ensure destination directory exists.
                                // Directory.CreateDirectory is idempotent: it does nothing if the directory already exists.
                                string destinationDir = Path.GetDirectoryName(this.RutaDestino);
                                if (!Directory.Exists(destinationDir))
                                {
                                    Directory.CreateDirectory(destinationDir);
                                }

                                // Copy file from source to destination.
                                // The 'true' parameter allows overwriting if the file already exists.
                                File.Copy(this.RutaOrigen, this.RutaDestino, true);
                            }
                            else
                            {
                                // If the source file does not exist, show an error message.
                                this.MensajeError("El archivo de imagen seleccionado no existe");
                            }
                        }
                        catch (Exception exFile)
                        {
                            // If any error occurs during file copy, show a detailed error message.
                            this.MensajeError("Error al copiar la imagen: " + exFile.Message);
                        }
                    }

                    // --- UI REFRESH ---
                    // Refresh the article list to show the newly inserted record.
                    this.Listar();
                }
                else
                {
                    // If the insert was not successful, show the error message returned by the business layer.
                    this.MensajeError(Rpta);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions and show a detailed error message with stack trace.
                // This is a last-resort error handler to prevent the application from crashing.
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                this.Limpiar();
                BtnInsertar.Visible = false;
                BtnActualizar.Visible = true;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                CboCategoria.SelectedValue = Convert.ToInt32(DgvListado.CurrentRow.Cells["IdCategoria"].Value);
                TxtCodigo.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Codigo"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtPrecioVenta.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Precio_Venta"].Value);
                TxtStock.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Stock"].Value);
                TxtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
                string Imagen;
                Imagen = Convert.ToString(DgvListado.CurrentRow.Cells["Imagen"].Value);

                if(Imagen != string.Empty)
                {
                    PicImagen.Image = Image.FromFile(this.Directorio + "\\" + Imagen);
                    TxtImagen.Text = Imagen;
                }
                else
                {
                    PicImagen.Image = null;
                    TxtImagen.Text = "";
                }
                TabGeneral.SelectedIndex = 1;
            } catch(Exception ex) {
                MessageBox.Show("Seleccione desde la celda." + " | Error: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear previous error icons
                ErrorIcono.Clear();
                bool isValid = true;

                // Validate ID
                if (string.IsNullOrWhiteSpace(TxtId.Text))
                {
                    ErrorIcono.SetError(TxtId, "Seleccione un registro para actualizar");
                    isValid = false;
                }

                // Validate category selection
                if (CboCategoria.SelectedValue == null || string.IsNullOrWhiteSpace(CboCategoria.Text))
                {
                    ErrorIcono.SetError(CboCategoria, "Seleccione una categoria");
                    isValid = false;
                }

                // Validate name
                if (string.IsNullOrWhiteSpace(TxtNombre.Text))
                {
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre");
                    isValid = false;
                }

                // Validate price
                if (string.IsNullOrWhiteSpace(TxtPrecioVenta.Text))
                {
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio de venta");
                    isValid = false;
                }
                else if (!decimal.TryParse(TxtPrecioVenta.Text, out decimal precioVenta) || precioVenta < 0)
                {
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio de venta válido (número positivo)");
                    isValid = false;
                }

                // Validate stock
                if (string.IsNullOrWhiteSpace(TxtStock.Text))
                {
                    ErrorIcono.SetError(TxtStock, "Ingrese el stock");
                    isValid = false;
                }
                else if (!int.TryParse(TxtStock.Text, out int stock) || stock < 0)
                {
                    ErrorIcono.SetError(TxtStock, "Ingrese un stock válido (número entero positivo)");
                    isValid = false;
                }

                if (!isValid)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    return;
                }

                // All validations passed, proceed with update
                string Rpta = NArticulo.Actualizar(
                    Convert.ToInt32(TxtId.Text),
                    Convert.ToInt32(CboCategoria.SelectedValue),
                    TxtCodigo.Text.Trim(),
                    this.NombreAnt,
                    TxtNombre.Text.Trim(),
                    Convert.ToDecimal(TxtPrecioVenta.Text),
                    Convert.ToInt32(TxtStock.Text),
                    TxtDescripcion.Text.Trim(),
                    TxtImagen.Text.Trim()
                );

                if (Rpta.Equals("OK"))
                {
                    this.MensajeOk("Se actualizó de forma correcta el registro");

                    // Handle image file copy if an image was selected
                    if (!string.IsNullOrWhiteSpace(TxtImagen.Text) && !string.IsNullOrWhiteSpace(this.RutaOrigen))
                    {
                        try
                        {
                            this.RutaDestino = Path.Combine(this.Directorio, TxtImagen.Text);

                            if (File.Exists(this.RutaOrigen))
                            {
                                string destinationDir = Path.GetDirectoryName(this.RutaDestino);
                                if (!Directory.Exists(destinationDir))
                                {
                                    Directory.CreateDirectory(destinationDir);
                                }
                                File.Copy(this.RutaOrigen, this.RutaDestino, true);
                            }
                            else
                            {
                                this.MensajeError("El archivo de imagen seleccionado no existe");
                            }
                        }
                        catch (Exception exFile)
                        {
                            this.MensajeError("Error al copiar la imagen: " + exFile.Message);
                        }
                    }

                    
                    this.Listar();
                }
                else
                {
                    this.MensajeError(Rpta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
