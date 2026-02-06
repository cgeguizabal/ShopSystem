using Sistema.Entities;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Security.Claims;


namespace Sistema.Data
{
    public class DUsuario
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
                SqlCommand Comando = new SqlCommand("usuario_listar", SqlCon);
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
                SqlCommand Comando = new SqlCommand("usuario_buscar", SqlCon); // Create the SqlCommand object to execute the stored procedure
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

        public DataTable Login(string Email, string Clave)
        {
            SqlDataReader Resultado; // To read the results from the database
            DataTable Tabla = new DataTable(); // To store the results in a table
            SqlConnection SqlCon = new SqlConnection(); // To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection(); // Get the connection to the database from the Connection class
                SqlCommand Comando = new SqlCommand("usuario_login", SqlCon); // Create the SqlCommand object to execute the stored procedure
                Comando.CommandType = CommandType.StoredProcedure; // Indicate that it is a stored procedure on the SQL Server

                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Clave;

                SqlCon.Open(); // Open the connection
                Resultado = Comando.ExecuteReader(); // Execute the command and store the result in Resultado
                Tabla.Load(Resultado); // Load the result into the DataTable
                return Tabla; // Return the DataTable with the results
            }
            catch (Exception ex)
            {
                return null;
                throw ex; // Throw the exception to be handled by the calling code
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close(); // Close the connection if it is open
            }
        }

        public string Existe(string Valor)
        {
            // Variable to store the response (will contain the output value or an error message)
            string Rpta = "";
            // SqlConnection: .NET class that manages a connection to a SQL Server database.
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // Get a configured SqlConnection object from the Connection class (singleton pattern).
                SqlCon = Connection.GetInstance().CreateConnection();

                // SqlCommand: .NET class used to execute SQL queries or stored procedures against SQL Server.
                // Here, it is initialized to execute the stored procedure named 'categoria_existe'.
                SqlCommand Comando = new SqlCommand("usuario_existe", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameter '@Valor' to the command, passing the value to search for.
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Valor;

                // Create a SqlParameter to receive the output value from the stored procedure.
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe"; // Name of the output parameter (must match the stored procedure)
                ParExiste.SqlDbType = SqlDbType.Int; // The type of the output parameter
                ParExiste.Direction = ParameterDirection.Output; // Specify that this is an output parameter

                // Add the output parameter to the command.
                Comando.Parameters.Add(ParExiste);

                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure (no result set expected, just output parameter).
                Comando.ExecuteNonQuery();

                // Retrieve the value of the output parameter and convert it to string.
                Rpta = Convert.ToString(ParExiste.Value);
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
            // Return the output value or error message.
            return Rpta;
        }

        public string Insertar(Usuario obj) // Insert method to add a new Categoria record, is using the model Categoria from Categoria.cs
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
                SqlCommand Comando = new SqlCommand("usuario_insertar", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameters '@nombre' and '@descripcion' to the command, using the values from the Categoria object.
                Comando.Parameters.Add("@Idrol", SqlDbType.Int).Value = obj.IdRol;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre; // This is the obj coming from the argument received using the model
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = obj.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = obj.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.Clave;

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

        public string Actualizar(Usuario obj)
        {
            // 'obj' is an instance of the Categoria class, defined in your model layer (Categoria.cs).
            // It is typically created and populated in the business or presentation layer, then passed to this method.
            // The properties of 'obj' (IdCategoria, Nombre, Descripcion) are used to set the parameters for the SQL stored procedure.
            // This ensures the correct record is updated in the database with the new data.
            // Variable to store the response ("OK" or error message)
            string Rpta = "";
            // SqlConnection: .NET class that manages a connection to a SQL Server database.
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // Get a configured SqlConnection object from the Connection class (singleton pattern).
                SqlCon = Connection.GetInstance().CreateConnection();

                // SqlCommand: .NET class used to execute SQL queries or stored procedures against SQL Server.
                // Here, it is initialized to execute the stored procedure named 'categoria_actualizar'.
                SqlCommand Comando = new SqlCommand("usuario_actualizar", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameters '@idcategoria', '@nombre', and '@descripcion' to the command, using the values from the Categoria object.
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario;
                Comando.Parameters.Add("@Idrol", SqlDbType.Int).Value = obj.IdRol;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre; // This is the obj coming from the argument received using the model
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = obj.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = obj.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.Clave;

                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure. ExecuteNonQuery returns the number of affected rows.
                // If one row was updated, return "OK", otherwise return an error message.
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Could not update the record";
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

        public string Eliminar(int Id)
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
                // Here, it is initialized to execute the stored procedure named 'categoria_eliminar'.
                SqlCommand Comando = new SqlCommand("usuario_eliminar", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameter '@idcategoria' to the command, using the provided Id.
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;

                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure. ExecuteNonQuery returns the number of affected rows.
                // If one row was deleted, return "OK", otherwise return an error message.
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Could not delete the record";
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

        public string Activar(int Id)
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
                // Here, it is initialized to execute the stored procedure named 'categoria_activar'.
                SqlCommand Comando = new SqlCommand("usuario_activar", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameter '@idcategoria' to the command, using the provided Id.
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;

                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure. ExecuteNonQuery returns the number of affected rows.
                // If one row was updated (activated), return "OK", otherwise return an error message.
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Could not activate the record";
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

        public string Desactivar(int Id)
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
                SqlCommand Comando = new SqlCommand("usuario_desactivar", SqlCon);

                // Set the command type to StoredProcedure.
                Comando.CommandType = CommandType.StoredProcedure;

                // Add the input parameter '@idcategoria' to the command, using the provided Id.
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;

                // Open the SQL Server database connection.
                SqlCon.Open();

                // Execute the stored procedure. ExecuteNonQuery returns the number of affected rows.
                // If one row was updated (deactivated), return "OK", otherwise return an error message.
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Could not deactivate the record";
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
