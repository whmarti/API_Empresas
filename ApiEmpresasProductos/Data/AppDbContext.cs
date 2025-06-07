using Microsoft.EntityFrameworkCore;
using ApiEmpresasProductos.Models;

namespace ApiEmpresasProductos.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Producto> Productos => Set<Producto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar la precisión de 'Costo'
        modelBuilder.Entity<Producto>()
            .Property(p => p.Costo)
            .HasPrecision(18, 2); // 18 dígitos totales, 2 decimales
            
        // Seed Empresas
        modelBuilder.Entity<Empresa>().HasData(
            new Empresa { Id = 1, Nombre = "TechCorp", Pais = "USA", NumeroSucursales = 5, NumeroEmpleados = 1000, Sector = "Tecnología" },
            new Empresa { Id = 2, Nombre = "AgroPlus", Pais = "Argentina", NumeroSucursales = 2, NumeroEmpleados = 300, Sector = "Agroindustria" },
            new Empresa { Id = 3, Nombre = "ConstruMax", Pais = "México", NumeroSucursales = 4, NumeroEmpleados = 450, Sector = "Construcción" },
            new Empresa { Id = 4, Nombre = "MediSalud", Pais = "Colombia", NumeroSucursales = 3, NumeroEmpleados = 500, Sector = "Salud" },
            new Empresa { Id = 5, Nombre = "EcoEnergy", Pais = "Chile", NumeroSucursales = 1, NumeroEmpleados = 150, Sector = "Energía" }
        );

        // Seed Productos
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Panel Solar", Descripcion = "Panel de alta eficiencia", Costo = 300, EmpresaId = 5 },
            new Producto { Id = 2, Nombre = "Software ERP", Descripcion = "ERP para empresas medianas", Costo = 1200, EmpresaId = 1 },
            new Producto { Id = 3, Nombre = "Tractor X200", Descripcion = "Tractor con GPS", Costo = 8000, EmpresaId = 2 },
            new Producto { Id = 4, Nombre = "Casco de seguridad", Descripcion = "Certificación internacional", Costo = 50, EmpresaId = 3 },
            new Producto { Id = 5, Nombre = "Suero Oral", Descripcion = "Fórmula pediátrica", Costo = 3, EmpresaId = 4 },
            new Producto { Id = 6, Nombre = "Andamio modular", Descripcion = "Andamio de aluminio", Costo = 400, EmpresaId = 3 },
            new Producto { Id = 7, Nombre = "CRM Web", Descripcion = "CRM multiusuario", Costo = 900, EmpresaId = 1 },
            new Producto { Id = 8, Nombre = "Generador eólico", Descripcion = "Turbina de baja velocidad", Costo = 10000, EmpresaId = 5 },
            new Producto { Id = 9, Nombre = "Pulverizador agrícola", Descripcion = "Alta precisión", Costo = 2500, EmpresaId = 2 },
            new Producto { Id = 10, Nombre = "Tensiómetro digital", Descripcion = "Para uso clínico", Costo = 80, EmpresaId = 4 }
        );
    }
}
