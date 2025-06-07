using ApiEmpresasProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpresasProductos.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEmpresasProductos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        // Incluimos la empresa por conveniencia; quítalo si no lo necesitas
        return await _context.Productos
                             .Include(p => p.Empresa)
                             .ToListAsync();
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _context.Productos
                                     .Include(p => p.Empresa)
                                     .FirstOrDefaultAsync(p => p.Id == id);

        if (producto is null)
            return NotFound();

        return producto;
    }

    // POST: api/Productos
    [HttpPost]
    public async Task<ActionResult<Producto>> CreateProducto(Producto producto)
    {
        // Validación básica opcional: asegurar que exista la Empresa
        var empresaExiste = await _context.Empresas.AnyAsync(e => e.Id == producto.EmpresaId);
        if (!empresaExiste)
            return BadRequest($"No existe la Empresa con Id {producto.EmpresaId}");

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        // Devuelve 201 con la ubicación del nuevo recurso
        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto(int id, Producto producto)
    {
        if (id != producto.Id)
            return BadRequest();

        var productoDb = await _context.Productos.FindAsync(id);
        if (productoDb is null)
            return NotFound();

        // Actualizar campos
        productoDb.Nombre       = producto.Nombre;
        productoDb.Descripcion  = producto.Descripcion;
        productoDb.Costo        = producto.Costo;
        productoDb.EmpresaId    = producto.EmpresaId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto is null)
            return NotFound();

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
