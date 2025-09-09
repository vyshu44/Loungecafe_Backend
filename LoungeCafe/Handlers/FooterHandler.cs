using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class FooterHandler
    {
        private readonly ILoungecafeRepository _repository;

        public FooterHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<FooterModel>> GetFooterDataAsync()
        {
            var data = await _repository.GetFooterDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Footer !!");
            }
            return data;
        }
    }
}
