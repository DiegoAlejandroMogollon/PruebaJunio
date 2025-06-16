namespace InventoryAPI.Models
{
    public class ProductS
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string TipoElaboracion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
