using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Data;


namespace Sistema.Business
{
    public class NRole
    {
        public static DataTable Listar()
        {
            DRole Data = new DRole();
            return Data.Listar();
        }
    }
}
