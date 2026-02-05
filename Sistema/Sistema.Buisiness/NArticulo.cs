using Sistema.Data;
using Sistema.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Business
{
    public class NArticulo
    {
        // Lists all categories by calling the Listar method from the data access layer.
        // Returns a DataTable containing all category records.
        public static DataTable Listar()
        {
            DArticulo Datos = new DArticulo();
            return Datos.Listar(); //This line calls the Listar method from DCategoria class
        }

        // Searches for categories matching the given value.
        // Calls the Buscar method from the data access layer and returns the results as a DataTable.
        public static DataTable Buscar(string Valor)
        {
            DArticulo Datos = new DArticulo();
            return Datos.Buscar(Valor); //This line calls the Buscar method from DCategoria class
        }

        // Inserts a new category.
        // First checks if a category with the same name already exists using the Existe method.
        // If it exists, returns a message indicating duplication.
        // Otherwise, creates a Categoria object, sets its properties, and calls the Insertar method in the data access layer.
        public static string Insertar(int IdCategoria, string Codigo, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            DArticulo Datos = new DArticulo(); //Creating an object of DCategoria class from Sistema.Data

            string Existe = Datos.Existe(Nombre); //This line calls the Existe method from DCategoria class
            if (Existe.Equals("1"))
            {
                // If the category already exists, return a message.
                return "La articulo ya existe.";
            }
            else
            {
                // Create a new Categoria entity and set its properties.
                Articulo Obj = new Articulo(); //Creating an object of Categoria class from Sistema.Entities
                Obj.IdCategoria = IdCategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;         
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                
                Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                                               // Pass the entity to the data access layer for insertion.
                Obj.Imagen = Imagen;
                return Datos.Insertar(Obj); //This line calls the Insertar method from DCategoria class}
            }
        }

        // Updates an existing category.
        // If the name hasn't changed, updates directly.
        // If the name has changed, checks for duplicates before updating.
        // Creates a Categoria entity, sets its properties, and calls the Actualizar method in the data access layer.
        public static string Actualizar(int Id, int IdCategoria, string Codigo, string NombreAnt, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            DArticulo Datos = new DArticulo(); //Creating an object of DCategoria class from Sistema.Data
            Articulo Obj = new Articulo(); //Creating an object of Categoria class from Sistema.Entities

            if (NombreAnt.Equals(Nombre))
            {
                // If the name hasn't changed, update directly.
                Obj.IdArticulo = Id;
                Obj.IdCategoria = IdCategoria; //Setting the IdCategoria property of Categoria object
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                Obj.Imagen = Imagen;
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
                    return "La articulo ya existe.";
                }
                else
                {
                    // Otherwise, update with the new name.
                    Obj.IdArticulo = Id;
                    Obj.IdCategoria = IdCategoria; //Setting the IdCategoria property of Categoria object
                    Obj.Codigo = Codigo;
                    Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                    Obj.PrecioVenta = PrecioVenta;
                    Obj.Stock = Stock;
                    Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                    Obj.Imagen = Imagen;
                    // Call the Actualizar method in the data access layer.
                    return Datos.Actualizar(Obj); //This line calls the Insertar method from DCategoria class
                }
            }
        }

        // Deletes a category by its Id.
        // Calls the Eliminar method in the data access layer.
        public static string Eliminar(int Id)
        {
            DArticulo Datos = new DArticulo(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Eliminar(Id); //This line calls the Eliminar method from DCategoria class
        }

        // Activates a category by its Id.
        // Calls the Activar method in the data access layer.
        public static string Activar(int Id)
        {
            DArticulo Datos = new DArticulo(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Activar(Id); //This line calls the Activar method from DCategoria class
        }

        // Deactivates a category by its Id.
        // Calls the Desactivar method in the data access layer.
        public static string Desactivar(int Id)
        {
            DArticulo Datos = new DArticulo(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Desactivar(Id); //This line calls the Desactivar method from DCategoria class
        }
    }
}
