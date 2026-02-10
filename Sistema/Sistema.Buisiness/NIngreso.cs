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
    public class NIngreso
    {

        public static DataTable Listar()
        {
            DIngreso Datos = new DIngreso();
            return Datos.Listar(); //This line calls the Listar method from DCategoria class
        }

        // Searches for categories matching the given value.
        // Calls the Buscar method from the data access layer and returns the results as a DataTable.
        public static DataTable Buscar(string Valor)
        {
            DIngreso Datos = new DIngreso();
            return Datos.Buscar(Valor); //This line calls the Buscar method from DCategoria class
        }

        public static DataTable ListarDetalle(int Id)
        {
            DIngreso Datos = new DIngreso();
            return Datos.ListarDetalle(Id); //This line calls the Buscar method from DCategoria class
        }

        public static string Insertar(int IdProveedor, int IdUsuario, string TipoComprobante, string SerieComprobante, string NumComprobante, decimal Impuesto, decimal Total, DataTable Detalles)
        {
            DIngreso Datos = new DIngreso(); //Creating an object of DCategoria class from Sistema.Data

            Ingreso obj = new Ingreso(); //Creating an object of Categoria class from Sistema.Entities
            obj.IdProveedor = IdProveedor;
            obj.IdUsuario = IdUsuario;
            obj.TipoComprobante = TipoComprobante;
            obj.SerieComprobante = SerieComprobante;
            obj.NumComprobante = NumComprobante;
            obj.Impuesto = Impuesto;
            obj.Total = Total;
            obj.Detalles = Detalles;
            return Datos.Insertar(obj); //This line calls the Insertar method from DCategoria class, passing the Categoria object as an argument
        }

        public static string Anular(int Id)
        {
            DIngreso Datos = new DIngreso(); //Creating an object of DCategoria class from Sistema.Data
            return Datos.Anular(Id); //This line calls the Anular method from DCategoria class, passing the IdCategoria as an argument

        }
    }
}
