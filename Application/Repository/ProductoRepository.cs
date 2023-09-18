

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly JwtAppContext _context;
    public ProductoRepository(JwtAppContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetProductosMasCaris(int Cantidad)
    {
        return await _context.Productos.OrderByDescending(e => e.Precio)
        .Take(Cantidad)
        .ToListAsync();
    }
    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
        .Include(e => e.Marca)
        .Include(e => e.Categoria)
        .FirstOrDefaultAsync(e => e.Id == id);
    }
    public  override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
        .Include(e => e.Marca)
        .Include(e => e.Categoria)
        .ToListAsync();
    }
}
