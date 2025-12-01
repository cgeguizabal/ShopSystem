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

        private string NombreAnt; //Variable to store the previous name of the category
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void Listar() //Method to list categories 
        {
            try
            {
                DgvListado.DataSource= NCategoria.Listar(); //Call to the business layer to get the list of categories
                this.Limpiar();
                this.Formato(); //Call to format the DataGridView
                LblTotal.Text = "Total registro: " + Convert.ToString(DgvListado.Rows.Count); //Display total number of records
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }
        private void Buscar() //Method to search categories
        {
            try {
                DgvListado.DataSource = NCategoria.Buscar(TxtBuscar.Text); //Call to the business layer to search categories based on the text in TxtBuscar
                this.Formato();
                LblTotal.Text = "Total registro: " + Convert.ToString(DgvListado.Rows.Count); //Display total number of records found

            } catch (Exception ex) {
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs

            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false; //   Hide the second column
            DgvListado.Columns[2].Width = 150;
            DgvListado.Columns[3].Width = 400;// Set width of the fourth column
            DgvListado.Columns[3].HeaderText = "Description"; //Change header text to English
            DgvListado.Columns[4].Width = 100;


        }

        private void Limpiar()
        {
           TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtDescripcion.Clear();
            TxtId.Clear();
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();


            DgvListado.Columns[0].Visible = false;
            BtnActivar.Visible = false;
            BtnDesactivar.Visible = false;
            BtnDesactivar.Visible = false;
            BtnEliminar.Visible = false;
            ChkSeleccion.Checked = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmCategoria_Load(object sender, EventArgs e) //   Event handler for form load event
        {
            this.Listar(); //Call to list categories when the form loads
        }
        
        private void BtnBuscar_Click(object sender, EventArgs e)//  Event handler for search button click event
        {
            this.Buscar(); //Call to search categories when the search button is clicked
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try {

                string  Rpta = ""; //Variable to store the response from the business layer
                if (TxtNombre.Text == string.Empty) //Check if the name textbox is empty
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados"); //Show error message if name is empty
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre"); //Set error icon on the name textbox
                }
                else
                {
                    Rpta = NCategoria.Insertar(TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim()); //Call to business layer to insert a new category
                    if (Rpta.Equals("OK")) //Check if the response is OK
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnInsertar.Visible = false;
                BtnActualizar.Visible = true;

                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
                TabGeneral.SelectedIndex = 1;
            } catch (Exception) 
            {
                MessageBox.Show("Seleccione desde la celda nombre"); //Show error message if exception occurs
              }
            }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

            try
            {

                string Rpta = ""; //Variable to store the response from the business layer
                if (TxtNombre.Text == string.Empty || TxtId.Text == string.Empty ) //Check if the name textbox is empty
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados"); //Show error message if name is empty
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre"); //Set error icon on the name textbox
                }
                else
                {
                    Rpta = NCategoria.Actualizar(Convert.ToInt32(TxtId.Text),this.NombreAnt, TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim()); //Call to business layer to insert a new category
                    if (Rpta.Equals("OK")) //Check if the response is OK
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
                MessageBox.Show(ex.Message + ex.StackTrace); //Show error message if exception occurs
            }
        }

        private void ChkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccion.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnActivar.Visible = true;
                BtnDesactivar.Visible = true;
                BtnDesactivar.Visible   = true;
                BtnEliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnActivar.Visible = false;
                BtnDesactivar.Visible = false;
                BtnDesactivar.Visible = false;
                BtnEliminar.Visible = false;
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
    }
}
