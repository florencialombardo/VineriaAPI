using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Services.Services
{
    public class CataService : ICataService
    {
        private readonly List<Cata> _catas = new();
        private readonly IUserService _userService;

        public CataService(IUserService userService)
        {
            _userService = userService;
        }

        public List<Cata> GetFutureCatas() =>
            _catas.Where(c => c.Date > DateTime.Now).ToList();

        public void AddGuestsToCata(int cataId, List<int> guestIds)
        {
            var cata = _catas.FirstOrDefault(c => c.Id == cataId);
            if (cata != null)
            {
                foreach (var guestId in guestIds)
                {
                    var user = _userService.GetUserByName(guestId);
                    if (user != null)
                    {
                        cata.Guests.Add(user);
                    }
                }
            }
        }
    }
}
}
