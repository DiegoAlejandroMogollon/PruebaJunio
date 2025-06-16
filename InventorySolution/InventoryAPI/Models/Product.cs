namespace InventoryAPI.Models;

public enum ProductStatus {  EnBodega,Vendido,Devuelto,Otro}
public enum ManufactureType { ElaboradoAMano,ElaboradoAManoYMaquina }

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ManufactureType ManufactureType { get; set; }
    public ProductStatus Status { get; set; }
}
