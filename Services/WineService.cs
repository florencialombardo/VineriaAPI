using VineriaAPI.Models;
using VineriaAPI.Repository;

namespace VineriaAPI.Services
{
    public class WineService
    {
        private readonly WineRepository _repository;

        public WineService(WineRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Wine>> GetAllWines()
        {
            return await _repository.GetAllWines();
        }

        public async Task<Wine> GetWineById(int id)
        {
            return await _repository.GetWineById(id);
        }

        public async Task AddWine(Wine wine)
        {
            await _repository.AddWine(wine);
        }

        public async Task UpdateWineStock(int id, int newStock)
        {
            await _repository.UpdateWineStock(id, newStock);
        }
    }

}
