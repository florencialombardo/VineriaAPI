using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.Services
{
    public interface IWineService
    {
        List<WineDTO> GetAllWines();
        WineDTO GetWineByName(string name);
        void RegisterWine(WineDTO wineDto);

        void AddStock(string name, int quantity);

        List<WineDTO> GetWineByVariety(string variety);
    }
}
