
namespace Sistema.Entities
{
    public class Categoria // Here I create the Categoria entity class to represent the Categoria table in the database, model layer
    {
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
