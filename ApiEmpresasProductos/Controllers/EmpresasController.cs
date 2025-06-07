using ApiEmpresasProductos.Data;
using ApiEmpresasProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresasProductos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmpresasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
    {
        return await _context.Empresas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Empresa>> GetEmpresa(int id)
    {
        var empresa = await _context.Empresas
            .Include(e => e.Productos)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (empresa == null)
            return NotFound();

        return empresa;
    }

    [HttpPost]
    public async Task<ActionResult<Empresa>> CreateEmpresa(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.Id }, empresa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmpresa(int id, Empresa empresa)
    {
        if (id != empresa.Id)
            return BadRequest();

        var empresaExistente = await _context.Empresas.FindAsync(id);
        if (empresaExistente == null)
            return NotFound();

        empresaExistente.Nombre = empresa.Nombre;
        empresaExistente.Pais = empresa.Pais;
        empresaExistente.NumeroSucursales = empresa.NumeroSucursales;
        empresaExistente.NumeroEmpleados = empresa.NumeroEmpleados;
        empresaExistente.Sector = empresa.Sector;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmpresa(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa == null)
            return NotFound();

        _context.Empresas.Remove(empresa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
