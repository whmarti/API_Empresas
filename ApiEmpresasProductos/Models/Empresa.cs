namespace ApiEmpresasProductos.Models;

public class Empresa 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public int NumeroSucursales { get; set; }
    public int NumeroEmpleados { get; set; }
    public string Sector { get; set; } = string.Empty;

    public List<Producto> Productos { get; set; } = new();
}