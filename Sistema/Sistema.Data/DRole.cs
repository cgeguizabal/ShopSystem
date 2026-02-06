using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.Data
{
    public class DRole
    {
        public DataTable Listar()
        {
            // SqlDataReader: .NET class that reads data from a SQL Server database in a forward-only, read-only manner.
            SqlDataReader Resultado;
            // DataTable: .NET class that represents an in-memory table of data (rows and columns). Used to store query results.
            DataTable Tabla = new DataTable();
            // SqlConnection: .NET class that manages a connection to a SQL Server database.
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // Get a configured SqlConnection object from the Connection class (custom singleton).
                SqlCon = Connection.GetInstance().CreateConnection();
                // SqlCommand: .NET class used to execute SQL queries or stored procedures against SQL Server.
                // Here, it is configured to execute the 'categoria_listar' stored procedure.
                SqlCommand Comando = new SqlCommand("role_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure; // Specify that the command is a stored procedure.
                SqlCon.Open(); // Open the database connection.
                // Execute the command and get a SqlDataReader to read the results.
                Resultado = Comando.ExecuteReader();
                // Load all rows from the SqlDataReader into the DataTable.
                Tabla.Load(Resultado);
                // Return the DataTable containing the results.
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex; // Propagate the exception to the calling code.
            }
            finally
            {
                // Ensure the connection is closed if it was opened.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
