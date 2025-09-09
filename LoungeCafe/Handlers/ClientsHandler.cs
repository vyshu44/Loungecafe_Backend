using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class ClientsHandler
    {
        private readonly ILoungecafeRepository _repository;

        public ClientsHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<ClientsModel>> GetClientsDataAsync()
        {
            var data = await _repository.GetClientsDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Clients !!");
            }
            return data;
        }
    }
}
