using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Data;

using Sistema.Entities;

namespace Sistema.Business
{
    public class NCategoria
    {
        public static DataTable Listar() {
            DCategoria Datos = new DCategoria();
            return Datos.Listar(); //This line calls the Listar method from DCategoria class
        }

        public static DataTable Buscar(string Valor) {
            DCategoria Datos = new DCategoria();
            return Datos.Buscar(Valor); //This line calls the Buscar method from DCategoria class

        }

        public static string Insertar(string Nombre, string Descripcion) { 

            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data

            string Existe = Datos.Existe(Nombre); //This line calls the Existe method from DCategoria class
            if (Existe.Equals("1"))
            {
                return "La categoria ya existe.";
            }
            else
            {
                Categoria Obj = new Categoria(); //Creating an object of Categoria class from Sistema.Entities
                Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                return Datos.Insertar(Obj); //This line calls the Insertar method from DCategoria class}

            }

            }

        public static string Actualizar(int Id, string Nombre, string Descripcion)
        {
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data

            string Existe = Datos.Existe(Nombre); //This line calls the Existe method from DCategoria class
            if (Existe.Equals("1"))
            {
                return "La categoria ya existe.";
            }
            else
            {

                Categoria Obj = new Categoria(); //Creating an object of Categoria class from Sistema.Entities
                Obj.IdCategoria = Id; //Setting the IdCategoria property of Categoria object
                Obj.Nombre = Nombre; //Setting the Nombre property of Categoria object
                Obj.Descripcion = Descripcion; //Setting the Descripcion property of Categoria object
                return Datos.Actualizar(Obj); //This line calls the Insertar method from DCategoria class}

            }
               
        }
        public static string Eliminar(int Id)
        { 
            DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Eliminar(Id); //This line calls the Eliminar method from DCategoria class
        }
        public static string Activar(int Id)
        { 
                DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Activar(Id); //This line calls the Activar method from DCategoria class
        }

        public static string Desactivar(int Id)
        
            { 
                DCategoria Datos = new DCategoria(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Desactivar(Id); //This line calls the Desactivar method from DCategoria class

        }

        }
}
