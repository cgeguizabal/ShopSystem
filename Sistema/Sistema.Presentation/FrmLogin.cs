using Sistema.Buisiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentation
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the application when the Cancel button is clicked
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Table = new DataTable();
                Table = NUsuario.Login(TxtEmail.Text, TxtClave.Text); // Calls the Login method from NUsuario class with the email and password entered by the user
                if (Table.Rows.Count <= 0)
                {
                    MessageBox.Show("El email o clave incorrecta", "Acceso al Sistema",MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays a message if no user is found with the provided credentials
                }
                else
                {
                    if (Convert.ToBoolean(Table.Rows[0][4])==false)
                    {
                        MessageBox.Show("Este Usuario no esta Activo.", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays a message if no user is found with the provided credentials

                    }
                    else
                    {
                        FrmPrincipal Frm = new FrmPrincipal(); // Creates an instance of the main form (FrmPrincipal)
                        Frm.Idusuario = Convert.ToInt32(Table.Rows[0][0]); // Sets the user ID in the main form
                        Frm.IdRol = Convert.ToInt32(Table.Rows[0][1]); // Sets the role ID in the main form
                        Frm.Rol = Convert.ToString(Table.Rows[0][2]); // Converts the role ID to an enum value and sets it in the main form
                        Frm.Nombre = Convert.ToString(Table.Rows[0][3]); // Sets the user's name in the main form
                        Frm.Estado = Convert.ToBoolean(Table.Rows[0][4]); // Sets the user's active status in the main form
                        Frm.Show(); // Displays the main form
                        this.Hide(); // Hides the login form
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace); // Displays an error message if an exception occurs during login

            }
        }
    }
}
