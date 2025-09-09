using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class AboutHandler
    {
        private readonly ILoungecafeRepository _repository;

        public AboutHandler(ILoungecafeRepository repo)

        {
            _repository = repo;
        }
        public async Task<List<AboutModel>> GetAboutDataAsync()
        {
            var data = await _repository.GetAboutDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table About !!");
            }
            return data;
        }
    }
}
