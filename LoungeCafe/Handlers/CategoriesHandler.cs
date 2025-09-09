using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class CategoriesHandler
    {
        private readonly ILoungecafeRepository _repository;

        public CategoriesHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<CategoriesModel>> GetCategoriesDataAsync()
        {
            var data = await _repository.GetCategoriesDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Categories !!");
            }
            return data;
        }
    }
}
