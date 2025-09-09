using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class AdditionalInfoHandler
    {
        private readonly ILoungecafeRepository _repository;

        public AdditionalInfoHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<AdditionalInfoModel>> GetAdditionalInfoDataAsync()
        {
            var data = await _repository.GetAdditionalInfoDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table AdditionalInfo !!");
            }
            return data;
        }
    }
}
