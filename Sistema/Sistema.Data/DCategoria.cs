using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System .Data.SqlClient;
using Sistema.Entities;


//Service / Data classes
namespace Sistema.Data
{
    public class DCategoria
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado; //To read the results from the database
            DataTable Tabla = new DataTable(); //To store the results in a table
            SqlConnection SqlCon = new SqlConnection(); //To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();//Get the connection to the database from the Connection class
                SqlCommand Comando = new SqlCommand("categoria_listar", SqlCon); //Create the SqlCommand object to execute the stored procedure
                Comando.CommandType = CommandType.StoredProcedure; //I indicate that it is a stored procedure on the sql server
                SqlCon.Open();//Open the connection
                Resultado = Comando.ExecuteReader(); //Execute the command and store the result in Resultado
                Tabla.Load(Resultado); //Load the result into the DataTable
                return Tabla; //Return the DataTable with the results
            }
            catch (Exception ex)
            {
                throw ex; //Throw the exception to be handled by the calling code
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
        }

        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado; //To read the results from the database
            DataTable Tabla = new DataTable(); //To store the results in a table
            SqlConnection SqlCon = new SqlConnection(); //To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();//Get the connection to the database from the Connection class
                SqlCommand Comando = new SqlCommand("categoria_buscar", SqlCon); //Create the SqlCommand object to execute the stored procedure
                Comando.CommandType = CommandType.StoredProcedure; //I indicate that it is a stored procedure on the sql server
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor; //Add the parameter to the command
                SqlCon.Open();//Open the connection
                Resultado = Comando.ExecuteReader(); //Execute the command and store the result in Resultado
                Tabla.Load(Resultado); //Load the result into the DataTable
                return Tabla; //Return the DataTable with the results
            }
            catch (Exception ex)
            {
                throw ex; //Throw the exception to be handled by the calling code
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
        }

        public string Existe(string Valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();//To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();
                SqlCommand Comando = new SqlCommand("categoria_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Valor; //Add the parameter to the command

                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";

                ParExiste.SqlDbType = SqlDbType.Int;//Define the type of the parameter
                ParExiste.Direction = ParameterDirection.Output;//  Define the direction of the parameter

                Comando.Parameters.Add(ParExiste); //Add the output parameter to the command

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
            return Rpta;
        }
        public string Insertar(Categoria obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();//To create the connection to the database

            try {
                SqlCon = Connection.GetInstance().CreateConnection();
                SqlCommand Comando = new SqlCommand("categoria_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre; //Add the parameter to the command
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion; //Add the parameter to the command
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
            return Rpta;
        }

        public string Actualizar(Categoria obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();//To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();
                SqlCommand Comando = new SqlCommand("categoria_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = obj.IdCategoria; //Add the parameter to the command
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre; //Add the parameter to the command
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion; //Add the parameter to the command
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
            return Rpta;
        }

        public string Eliminar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();//To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();
                SqlCommand Comando = new SqlCommand("categoria_eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id; //Add the parameter to the command


                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
            return Rpta;
        }

        public string Activar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();//To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();
                SqlCommand Comando = new SqlCommand("categoria_activar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id; //Add the parameter to the command


                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
            return Rpta;
        }

        public string Desactivar(int Id)
        {

            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();//To create the connection to the database

            try
            {
                SqlCon = Connection.GetInstance().CreateConnection();
                SqlCommand Comando = new SqlCommand("categoria_desactivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id; //Add the parameter to the command


                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//Close the connection if it is open
            }
            return Rpta;
        }
    }

}
