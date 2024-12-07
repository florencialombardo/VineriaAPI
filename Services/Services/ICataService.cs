using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Services.Services
{
    public interface ICataService
    {
        List<Cata> GetCatasFuturas();
        void AddGuestsToCata(int cataId, List<User> userid);
    }
}
