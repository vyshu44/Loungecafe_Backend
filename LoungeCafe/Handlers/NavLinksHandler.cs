using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class NavLinksHandler
    {
        private readonly ILoungecafeRepository _repository;

        public NavLinksHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<NavLinksModel>> GetNavLinksDataAsync()
        {
            var data = await _repository.GetNavLinksDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table NavLinks !!");
            }
            return data;
        }

    }
}
