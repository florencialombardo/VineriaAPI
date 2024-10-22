using VineriaAPI.Data;
using VineriaAPI.Models;

namespace VineriaAPI.Repository
{
    public class WineRepository 
    {
        private readonly ApplicationDbContext _context;

        public WineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Wine> GetAllWines() 
        { 
            return _context.Wines.ToList();
        }

        public async Task<Wine> GetWineById(int id)
        {
            return await _context.Wines.FindAsync(id);
        }

        public async Task AddWine(Wine wine)
        {
            await _context.Wines.AddAsync(wine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWineStock(int id, int newStock)
        {
            var wine = await _context.Wines.FindAsync(id);
            if (wine != null)
            {
                wine.Stock = newStock;
                await _context.SaveChangesAsync();
            }
        }
    }
}
