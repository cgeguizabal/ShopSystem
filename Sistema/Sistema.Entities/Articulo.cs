

namespace Sistema.Entities
{
    // The Articulo class represents the 'Articulo' (Article/Product) entity in the system.
    // This class is part of the Entities (Model) layer and is used to map the structure of the 'Articulo' table in the database.
    public class Articulo
    {
        // Unique identifier for the article (primary key in the database).
        public int IdArticulo { get; set; }

        // Foreign key referencing the category to which this article belongs.
        public int IdCategoria { get; set; }

        // Code used to uniquely identify the article (e.g., SKU or barcode).
        public string Codigo { get; set; }

        // Name of the article.
        public string Nombre { get; set; }

        // Sale price of the article.
        public decimal PrecioVenta { get; set; }

        // Current stock quantity of the article.
        public int Stock { get; set; }

        // Description of the article, providing additional details.
        public string Descripcion { get; set; }

        // Path or filename of the image associated with the article.
        public string Imagen { get; set; }

        // Indicates whether the article is active (true) or inactive (false).
        public bool Estado { get; set; }
    }
}
