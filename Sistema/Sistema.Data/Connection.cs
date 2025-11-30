using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema.Data
{
    public class Connection // Here I create the Connection class to manage the database connection
    {
        private string Base;
        private string Server;
        private string User;
        private string Password;
        private bool Security;

        private static Connection con = null;

        private Connection()
        {
            // Constructor privado para evitar instanciación externa
            this.Base = "dbsistema";
            this.Server = @"(local)\SQLEXPRESS";
            this.User = "sa";
            this.Password = "Cgeo14051997";
            this.Security = true;
        }
        

        public SqlConnection CreateConnection() {
        SqlConnection cadena = new SqlConnection();
            try
            { 
                cadena.ConnectionString = "Server=" + this.Server + ";Database=" + this.Base + ";";
                //Standard Security
                // Server=myServerAddress;Database=myDataBase;
                if (this.Security) //Windows Security authentication
                {
                    cadena.ConnectionString = cadena.ConnectionString + "Integrated Security=SSPI;";
                }
                else
                {
                    cadena.ConnectionString = cadena.ConnectionString + "User Id=" + this.User + ";Password=" + this.Password + ";";
                                                                      //User Id = myUsername; Password = myPassword;
                }
                
                    
                
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }
            return cadena;
        }
        public static Connection GetInstance()
        {
            if (con == null)
            {
                con = new Connection();
            }
            return con;
        }
    }

}
