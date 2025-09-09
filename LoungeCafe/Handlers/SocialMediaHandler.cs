using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class SocialMediaHandler
    {
        private readonly ILoungecafeRepository _repository;

        public SocialMediaHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<SocialMediaModel>> GetSocialMediaDataAsync()
        {
            var data = await _repository.GetSocialMediaDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table SocialMedia !!");
            }
            return data;
        }

    }
}
