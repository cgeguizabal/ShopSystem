using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema.Data
{
    // This class manages the database connection using the Singleton pattern
    public class Connection
    {
        // Private fields to store connection parameters
        private string Base;     // Database name
        private string Server;   // Server name or address
        private string User;     // Username for SQL authentication
        private string Password; // Password for SQL authentication
        private bool Security;   // If true, use Windows Authentication (Integrated Security)

        // Static field to hold the single instance of this class (Singleton pattern)
        private static Connection con = null;

        // Private constructor to prevent external instantiation
        private Connection()
        {
            // Initialize connection parameters
            this.Base = "dbsistema"; // Name of the database
            this.Server = "DESKTOP-MFB8UPO\\INTERGUIASQL"; // SQL Server instance
            this.User = "MyTestUser"; // SQL Server username
            this.Password = "14051997"; // SQL Server password
            this.Security = true; // Use Windows Authentication if true
        }

        // This method creates and returns a SqlConnection object configured with the connection string
        // sqlConnection is a class type that allows us to connect to a SQL Server database
        public SqlConnection CreateConnection()
        {
            // 'SqlConnection' is a .NET class representing a connection to a SQL Server database.
            // Here, we create a new instance using its default constructor (no parameters).
            SqlConnection cadena = new SqlConnection();

            try
            {
                // Build the base of the connection string with server and database
                cadena.ConnectionString = "Server=" + this.Server + ";Database=" + this.Base + ";";

                // If using Windows Authentication (Integrated Security)
                if (this.Security)
                {
                    // Append Integrated Security to the connection string
                    cadena.ConnectionString = cadena.ConnectionString + "Integrated Security=SSPI;";
                }
                else
                {
                    // Otherwise, use SQL Server authentication with username and password
                    cadena.ConnectionString = cadena.ConnectionString + "User Id=" + this.User + ";Password=" + this.Password + ";";
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, set the connection object to null and rethrow the exception
                cadena = null;
                throw ex;
            }

            // Return the configured SqlConnection object
            return cadena;
        }

        // Static method to get the single instance of the Connection class (Singleton pattern)
        public static Connection GetInstance()
        {
            // If the instance does not exist, create it
            if (con == null)
            {
                con = new Connection();
            }
            // Return the single instance
            return con;
        }
    }

}
