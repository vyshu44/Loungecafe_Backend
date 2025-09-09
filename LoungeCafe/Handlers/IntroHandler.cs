using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class IntroHandler
    {
        private readonly ILoungecafeRepository _repository;

        public IntroHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<IntroModel>> GetIntroDataAsync()
        {
            var data = await _repository.GetIntroDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Intro !!");
            }
            return data;
        }
    }
}
