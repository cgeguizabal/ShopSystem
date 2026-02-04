using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Data;

using Sistema.Entities;

namespace Sistema.Business // Here I create the business logic layer namespace, here I use the Data and Entities layers and manupulate the data
{
    public class NCategoria
    {
        // Lists all categories by calling the Listar method from the data access layer.
        // Returns a DataTable containing all category records.
        public static DataTable Listar()
        {
            DCategoria Datos = new DCategoria();
            return Datos.Listar(); //This line calls the Listar method from DCategoria class
        }

        // Searches for categories matching the given value.
        // Calls the Buscar method from the data access layer and returns the results as a DataTable.
        public static DataTable Buscar(string Valor)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Buscar(Valor); //This line calls the Buscar method from DCategoria class
        }

        public static DataTable Seleccionar()
        {
            DCategoria Datos = new DCategoria();
            return Datos.Seleccionar(); //This line calls the Listar method from DCategoria class
        }

        // Inserts a new category.
        // First checks if a category with the same name already exists using the Existe method.
        // If it exists, returns a message indicating duplication.
        // Otherwise, creates a Categoria object, sets its properties, and calls the Insertar method in the data access layer.
        public static string Insertar(string Nombre, string Descripcion)
        {
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data

            string Existe = Datos.Existe(Nombre); //This line calls the Existe method from DCategoria class
            if (Existe.Equals("1"))
            {
                // If the category already exists, return a message.
                return "La categoria ya existe.";
            }
            else
            {
                // Create a new Categoria entity and set its properties.
                Categoria Obj = new Categoria(); //Creating an object of Categoria class from Sistema.Entities
                Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                                               // Pass the entity to the data access layer for insertion.
                return Datos.Insertar(Obj); //This line calls the Insertar method from DCategoria class}
            }
        }

        // Updates an existing category.
        // If the name hasn't changed, updates directly.
        // If the name has changed, checks for duplicates before updating.
        // Creates a Categoria entity, sets its properties, and calls the Actualizar method in the data access layer.
        public static string Actualizar(int Id, string NombreAnt, string Nombre, string Descripcion)
        {
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            Categoria Obj = new Categoria(); //Creating an object of Categoria class from Sistema.Entities

            if (NombreAnt.Equals(Nombre))
            {
                // If the name hasn't changed, update directly.
                Obj.IdCategoria = Id; //Setting the IdCategoria property of Categoria object
                Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                                               // Call the Actualizar method in the data access layer.
                return Datos.Actualizar(Obj); //This line calls the Insertar method from DCategoria class
            }
            else
            {
                // If the name has changed, check for duplicates.
                string Existe = Datos.Existe(Nombre); //This line calls the Existe method from DCategoria class
                if (Existe.Equals("1"))
                {
                    // If the new name already exists, return a message.
                    return "La categoria ya existe.";
                }
                else
                {
                    // Otherwise, update with the new name.
                    Obj.IdCategoria = Id; //Setting the IdCategoria property of Categoria object
                    Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                    Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                                                   // Call the Actualizar method in the data access layer.
                    return Datos.Actualizar(Obj); //This line calls the Insertar method from DCategoria class
                }
            }
        }

        // Deletes a category by its Id.
        // Calls the Eliminar method in the data access layer.
        public static string Eliminar(int Id)
        {
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Eliminar(Id); //This line calls the Eliminar method from DCategoria class
        }

        // Activates a category by its Id.
        // Calls the Activar method in the data access layer.
        public static string Activar(int Id)
        {
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Activar(Id); //This line calls the Activar method from DCategoria class
        }

        // Deactivates a category by its Id.
        // Calls the Desactivar method in the data access layer.
        public static string Desactivar(int Id)
        {
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Desactivar(Id); //This line calls the Desactivar method from DCategoria class
        }
    }
}
