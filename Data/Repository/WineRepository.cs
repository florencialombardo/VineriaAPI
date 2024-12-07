using Data;
using Data.Entities;

namespace Data.Repository
{
    public class WineRepository
    {
        private readonly ApplicationDbContext _context;

        public WineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }

        public Wine? GetWineByName(int id)
        {
            return _context.Wines.Find(id);
        }

        public int AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
            return wine.Id;
        }

        public bool UpdateWineStock(int id, int newStock)
        {
            var wine = _context.Wines.Find(id);
            if (wine != null)
            {
                wine.Stock = newStock;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
