using System;
using System.Data.SqlClient;
using System.Data;
using Sistema.Entities;

namespace Sistema.Data
{
    public class DIngreso
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
                SqlCommand Comando = new SqlCommand("ingreso_listar", SqlCon);
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

        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado; // To read the results from the database
            DataTable Tabla = new DataTable(); // To store the results in a table
            SqlConnection SqlCon = new SqlConnection(); // To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection(); // Get the connection to the database from the Connection class
                SqlCommand Comando = new SqlCommand("ingreso_buscar", SqlCon); // Create the SqlCommand object to execute the stored procedure
                Comando.CommandType = CommandType.StoredProcedure; // Indicate that it is a stored procedure on the SQL Server
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor; // Add the parameter to the command
                SqlCon.Open(); // Open the connection
                Resultado = Comando.ExecuteReader(); // Execute the command and store the result in Resultado
                Tabla.Load(Resultado); // Load the result into the DataTable
                return Tabla; // Return the DataTable with the results
            }
            catch (Exception ex)
            {
                throw ex; // Throw the exception to be handled by the calling code
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close(); // Close the connection if it is open
            }
        }

        public string Insertar(Ingreso obj) // Insert method to add a new Categoria record, is using the model Categoria from Categoria.cs
        {
            // 'obj' is an instance of the Categoria class, defined in your model layer (Categoria.cs).
            // It is typically created and populated in the business or presentation layer, then passed to this method.
            // The properties of 'obj' (Nombre, Descripcion) are used to set the parameters for the SQL stored procedure.
            // This ensures the correct data is inserted into the database.
            // Variable to store the response ("OK" or error message)
            string Rpta = "";
            // SqlConnection: .NET class that manages a connection to a SQL Server database.
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // Get a configured SqlConnection object from the Connection class (singleton pattern).
                SqlCon = Connection.GetInstance().CreateConnection();

                // SqlCommand: .NET class used to execute SQL queries or stored procedures against SQL Server.
                // Here, it is initialized to execute the stored procedure named 'categoria_insertar'.
                SqlCommand Comando = new SqlCommand("ingreso_insertar", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameters '@nombre' and '@descripcion' to the command, using the values from the Categoria object.
                Comando.Parameters.Add("@idproveedor", SqlDbType.Int).Value = obj.IdProveedor; // This is the obj coming from the argument received using the model
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario;
                Comando.Parameters.Add("@tipo_comprobante", SqlDbType.VarChar).Value = obj.TipoComprobante;
                Comando.Parameters.Add("@serie_comprobante", SqlDbType.VarChar).Value = obj.SerieComprobante;
                Comando.Parameters.Add("@num_comprobante", SqlDbType.VarChar).Value = obj.NumComprobante;
                Comando.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = obj.Impuesto;
                Comando.Parameters.Add("@total", SqlDbType.Decimal).Value = obj.Total;
                Comando.Parameters.Add("@detalle", SqlDbType.Structured).Value = obj.Detalles; // Assuming Detalles is a DataTable that matches the expected table-valued parameter in the stored procedure


                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure. ExecuteNonQuery returns the number of affected rows.
                // If one row was inserted, return "OK", otherwise return an error message.
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Could not insert the record";
            }
            catch (Exception ex)
            {
                // If an exception occurs, store the error message in the response variable.
                Rpta = ex.Message;
            }
            finally
            {
                // Ensure the database connection is closed if it was opened.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            // Return the result ("OK" or error message).
            return Rpta;
        }


        public string Anular(int Id)
        {
            // Variable to store the response ("OK" or error message)
            string Rpta = "";
            // SqlConnection: .NET class that manages a connection to a SQL Server database.
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // Get a configured SqlConnection object from the Connection class (singleton pattern).
                SqlCon = Connection.GetInstance().CreateConnection();

                // SqlCommand: .NET class used to execute SQL queries or stored procedures against SQL Server.
                // Here, it is initialized to execute the stored procedure named 'categoria_desactivar'.
                SqlCommand Comando = new SqlCommand("ingreso_anular", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameter '@idcategoria' to the command, using the provided Id.
                Comando.Parameters.Add("@idingreso", SqlDbType.Int).Value = Id;

                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure. ExecuteNonQuery returns the number of affected rows.
                // If one row was updated (deactivated), return "OK", otherwise return an error message.
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo anular el registro";
            }
            catch (Exception ex)
            {
                // If an exception occurs, store the error message in the response variable.
                Rpta = ex.Message;
            }
            finally
            {
                // Ensure the database connection is closed if it was opened.
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            // Return the result ("OK" or error message).
            return Rpta;
        }
    }
}
