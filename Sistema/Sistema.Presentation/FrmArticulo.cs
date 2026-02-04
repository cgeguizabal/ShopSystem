using Sistema.Business;
using System;
using System.Drawing;
using System.Windows.Forms;
using BarcodeStandard;
using SkiaSharp;
using System.IO;
using System.Drawing.Imaging;


namespace Sistema.Presentation
{
    public partial class FrmArticulo : Form
    {
        private string RutaOrigen; // Variable to store the original path of the image.
        private string RutaDestino; // Variable to store the destination path where the image will be saved.
        private string Directorio = "C:\\Users\\interguia\\source\\repos\\cgeguizabal\\ShopSystem"; // Directory where images will be stored.

        public FrmArticulo()
        {
            InitializeComponent();
        }

        // Lists all categories and updates the DataGridView.
        private void Listar() //Method to list categories 
        {
            try
            {
                // Sets the DataSource of DgvListado to the result of NCategoria.Listar(), which returns all categories.
                DgvListado.DataSource = NArticulo.Listar(); //Call to the business layer to get the list of categories
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
                DgvListado.DataSource = NArticulo.Buscar(TxtBuscar.Text); //Call to the business layer to search categories based on the text in TxtBuscar
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
            DgvListado.Columns[2].Visible = false; // Hide the second column (could be internal data).
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[3].HeaderText = "Categoria";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Codigo";
            DgvListado.Columns[5].Width = 150;
            DgvListado.Columns[6].Width = 100;
            DgvListado.Columns[6].HeaderText = "Precio Venta";
            DgvListado.Columns[7].Width = 60;
            DgvListado.Columns[8].Width = 200;
            DgvListado.Columns[8].HeaderText = "Descripcion";
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;

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

        private void CargarCategoria()
        {
            try
            {

                CboCategoria.DataSource = NCategoria.Seleccionar();
                CboCategoria.ValueMember = "IdCategoria";
                CboCategoria.DisplayMember = "Nombre";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarCategoria();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog instance to allow the user to select an image file.
            OpenFileDialog file = new OpenFileDialog();

            // Set the filter to only show image files with .jpg, .jpeg, or .png extensions.
            file.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            // Show the file dialog and check if the user clicked OK (selected a file).
            if (file.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image file into the PictureBox control (PicImagen).
                // Image.FromFile creates an Image object from the file path provided.
                PicImagen.Image = Image.FromFile(file.FileName);

                // Extract the file name (without the path) and set it in the TxtImagen textbox.
                // file.FileName.LastIndexOf("\\") finds the last backslash, so Substring gets the file name only.
                TxtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);

                // Store the full path of the selected image in the RutaOrigen variable for later use (e.g., saving or copying).
                this.RutaOrigen = file.FileName;
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {

            try
            {
                BarcodeStandard.Barcode Codigo = new BarcodeStandard.Barcode();
                Codigo.IncludeLabel = true;

                // Genera el código de barras como SKImage
                SKImage skImage = Codigo.Encode(
                    BarcodeStandard.Type.Code128,
                    "123456",
                    SKColors.Black,
                    SKColors.White,
                    300,
                    100
                );

                // Convierte SKImage a System.Drawing.Image para el PictureBox
                using (SKData data = skImage.Encode(SKEncodedImageFormat.Png, 100))
                using (MemoryStream ms = new MemoryStream(data.ToArray()))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    PanelCodigo.BackgroundImage = bitmap;  
                    PanelCodigo.BackgroundImageLayout = ImageLayout.Zoom; // Ajusta el tamaño
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de barras: " + ex.Message);
            }
        }

        private void BtnGuardarCodigo_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)PanelCodigo.BackgroundImage.Clone();

            SaveFileDialog DialogGuardar = new SaveFileDialog();

            DialogGuardar.AddExtension = true;
            DialogGuardar.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            DialogGuardar.ShowDialog();
            if(!string.IsNullOrEmpty(DialogGuardar.FileName))
            {
                imgFinal.Save(DialogGuardar.FileName, ImageFormat.Png);
            }
            imgFinal.Dispose();

        }
    }
}
