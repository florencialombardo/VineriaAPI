using System.Collections;
using Data.Entities;
using Data.Repository;
using Services.DTOs;

namespace Services.Services
{
    public class WineService : IWineService
    {
        private readonly WineRepository _repository;

        public WineService(WineRepository repository)
        {
            _repository = repository;
        }

        public List<WineDTO> GetAllWines()
        {
            var wines = _repository.GetWines();
            return wines.Select(w => new WineDTO
            {
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }

        public void RegisterWine(WineDTO wineDto)
        {
            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };

            _repository.AddWine(wine);
        }

        public bool UpdateWineStock(int id, int newStock)
        {
            return _repository.UpdateWineStock(id, newStock);
        }

        

        public WineDTO GetWineByName(string name)
        {
            public WineDTO GetWineByName(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));
                }


                var wine = _repository.GetWineByName(name);
                if (wine == null)
                {
                    return null;
                }


                return new WineDTO
                {
                    Name = wine.Name,
                    Variety = wine.Variety,
                    Year = wine.Year,
                    Region = wine.Region,
                    Stock = wine.Stock
                };
            }
        }

       

        public List<WineDTO> GetWineByVariety(string variety)
        {
            throw new NotImplementedException();
        }

        public void AddStock(string name, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre del vino no puede estar vacío.", nameof(name));
            }

            var wine = _repository.GetWineByName(name);
            if (wine != null)
            {
                wine.Stock += quantity;
                _repository.UpdateWine(wine);
            }
            else
            {
                throw new Exception($"El vino '{name}' no existe en el inventario.");
            }
        }
    }

}
