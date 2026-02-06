using Sistema.Data;
using Sistema.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Buisiness
{
    public class NUsuario
    {
        public static DataTable Listar()
        {
            DUsuario Datos = new DUsuario();
            return Datos.Listar(); //This line calls the Listar method from DUsuario class
        }

        // Searches for users matching the given value.
        // Calls the Buscar method from the data access layer and returns the results as a DataTable.
        public static DataTable Buscar(string Valor)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Buscar(Valor); //This line calls the Buscar method from DUsuario class
        }

        public static DataTable Login(string Email, string Clave)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Login(Email, Clave); //This line calls the Buscar method from DUsuario class
        }

        // Inserts a new user.
        // First checks if a user with the same name already exists using the Existe method.
        // If it exists, returns a message indicating duplication.
        // Otherwise, creates a Usuario object, sets its properties, and calls the Insertar method in the data access layer.
        public static string Insertar(int IdRol,  string Nombre, string TipoDocumento,  string NumDocumento, string Direccion, string Telefono, string Email, string Clave)
        {
            DUsuario Datos = new DUsuario(); // Creating an object of DUsuario class from Sistema.Data

            string Existe = Datos.Existe(Email); // Check if the user already exists
            if (Existe.Equals("1"))
            {
                return "El usuario ya existe.";
            }
            else
            {
                // Create a new Usuario entity and set its properties
                Usuario Obj = new Usuario();
                Obj.IdRol = IdRol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;

                // Pass the entity to the data access layer for insertion
                return Datos.Insertar(Obj);
            }
        }

        // Updates an existing user.
        // If the name hasn't changed, updates directly.
        // If the name has changed, checks for duplicates before updating.
        // Creates a Usuario entity, sets its properties, and calls the Actualizar method in the data access layer.  
        public static string Actualizar(int Id, int IdRol, string Nombre, string TipoDocumento, string NumDocumento, string Direccion, string Telefono, string EmailAnt, string Email, string Clave)
        {
            DUsuario Datos = new DUsuario(); //Creating an object of DUsuario class from Sistema.Data
            Usuario Obj = new Usuario(); //Creating an object of Usuario class from Sistema.Entities

            if (EmailAnt.Equals(Email))
            {
                // If the name hasn't changed, update directly.
                Obj.IdUsuario = Id;
                Obj.IdRol = IdRol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                // Call the Actualizar method in the data access layer.
                return Datos.Actualizar(Obj); //This line calls the Actualizar method from DUsuario class
            }
            else
            {
                // If the name has changed, check for duplicates.
                string Existe = Datos.Existe(Email); //This line calls the Existe method from DUsuario class
                if (Existe.Equals("1"))
                {
                    // If the new name already exists, return a message.
                    return "El usuario ya existe.";
                }
                else
                {
                    // Otherwise, update with the new name.
                    Obj.IdUsuario = Id;
                    Obj.IdRol = IdRol;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    Obj.Clave = Clave; 
                                       // Call the Actualizar method in the data access layer.
                    return Datos.Actualizar(Obj); //This line calls the Actualizar method from DUsuario class
                }
            }
        }

        // Deletes a user by its Id.
        // Calls the Eliminar method in the data access layer.
        public static string Eliminar(int Id)
        {
            DUsuario Datos = new DUsuario(); //Creating an object of DUsuario class from Sistema.Data
            return Datos.Eliminar(Id); //This line calls the Eliminar method from DUsuario class
        }

        // Activates a user by its Id.
        // Calls the Activar method in the data access layer.
        public static string Activar(int Id)
        {
            DUsuario Datos = new DUsuario(); //Creating an object of DUsuario class from Sistema.Data
            return Datos.Activar(Id); //This line calls the Activar method from DUsuario class
        }

        // Deactivates a user by its Id.
        // Calls the Desactivar method in the data access layer.
        public static string Desactivar(int Id)
        {
            DUsuario Datos = new DUsuario(); //Creating an object of DUsuario class from Sistema.Data
            return Datos.Desactivar(Id); //This line calls the Desactivar method from DUsuario class
        }
    }
}
