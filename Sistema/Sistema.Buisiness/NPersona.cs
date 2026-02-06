using Sistema.Data;
using Sistema.Entities;

using System.Data;



namespace Sistema.Buisiness
{
    public class NPersona
    {
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar(); //This line calls the Listar method from DUsuario class
        }

        public static DataTable ListarProvedores()
        {
            DPersona Datos = new DPersona();
            return Datos.ListarProveedores(); //This line calls the Listar method from DUsuario class
        }

        public static DataTable ListarClientes()
        {
            DPersona Datos = new DPersona();
            return Datos.ListarClientes(); //This line calls the Listar method from DUsuario class
        }

        public static DataTable Buscar(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.Buscar(Valor); //This line calls the Buscar method from DUsuario class
        }

        public static DataTable BuscarProveedores(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.BuscarProveedores(Valor); //This line calls the Buscar method from DUsuario class
        }

        public static DataTable BuscarClientes(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.BuscarClientes(Valor); //This line calls the Buscar method from DUsuario class
        }

        public static string Insertar(string TipoPersona, string Nombre, string TipoDocumento, string NumDocumento, string Direccion, string Telefono, string Email)
        {
            DPersona Datos = new DPersona(); // Creating an object of DUsuario class from Sistema.Data

            string Existe = Datos.Existe(Email); // Check if the user already exists
            if (Existe.Equals("1"))
            {
                return "El persona ya existe.";
            }
            else
            {
                // Create a new Usuario entity and set its properties
                Persona Obj = new Persona();
                Obj.TipoPersona = TipoPersona;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;

                // Pass the entity to the data access layer for insertion
                return Datos.Insertar(Obj);
            }
        }

        // Updates an existing user.
        // If the name hasn't changed, updates directly.
        // If the name has changed, checks for duplicates before updating.
        // Creates a Usuario entity, sets its properties, and calls the Actualizar method in the data access layer.  
        public static string Actualizar(int Id, string TipoPersona, string NombreAnt, string Nombre, string TipoDocumento, string NumDocumento, string Direccion, string Telefono,  string Email)
        {
            DPersona Datos = new DPersona(); //Creating an object of DUsuario class from Sistema.Data
            Persona Obj = new Persona(); //Creating an object of Usuario class from Sistema.Entities

            if (NombreAnt.Equals(Nombre))
            {
                // If the name hasn't changed, update directly.
                Obj.IdPersona = Id;
                Obj.TipoPersona = TipoPersona;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                // Call the Actualizar method in the data access layer.
                return Datos.Actualizar(Obj); //This line calls the Actualizar method from DUsuario class
            }
            else
            {
                // If the name has changed, check for duplicates.
                string Existe = Datos.Existe(Nombre); //This line calls the Existe method from DUsuario class
                if (Existe.Equals("1"))
                {
                    // If the new name already exists, return a message.
                    return "La Persona con ese nombre ya existe.";
                }
                else
                {
                    // Otherwise, update with the new name.
                    Obj.IdPersona = Id;
                    Obj.TipoPersona = TipoPersona;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    // Call the Actualizar method in the data access layer.
                    return Datos.Actualizar(Obj); //This line calls the Actualizar method from DUsuario class
                }
            }
        }

        // Deletes a user by its Id.
        // Calls the Eliminar method in the data access layer.
        public static string Eliminar(int Id)
        {
            DPersona Datos = new DPersona(); //Creating an object of DUsuario class from Sistema.Data
            return Datos.Eliminar(Id); //This line calls the Eliminar method from DUsuario class
        }
    }
}
