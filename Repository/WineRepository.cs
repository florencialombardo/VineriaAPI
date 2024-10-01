using VineriaAPI.Models;

namespace VineriaAPI.Repository
{
    public class WineRepository
    {
        private readonly List<Wine> _wines = new();
        private readonly List<User> _users = new();

        // Añadir un nuevo vino
        public void AddWine(Wine wine) => _wines.Add(wine);

        // Consultar todos los vinos
        public IEnumerable<Wine> GetWines() => _wines;

        // Consultar un vino por nombre
        public Wine? GetWineByName(string name) => _wines.FirstOrDefault(w => w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        // Añadir un nuevo usuario
        public void AddUser(User user) => _users.Add(user);
    }
}
