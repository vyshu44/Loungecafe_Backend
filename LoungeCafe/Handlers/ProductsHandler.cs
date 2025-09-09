using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class ProductsHandler
    {
        private readonly ILoungecafeRepository _repository;

        public ProductsHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<ProductsModel>> GetProductsDataAsync()
        {
            var data = await _repository.GetProductsDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Products !!");
            }
            return data;
        }
    }
}
