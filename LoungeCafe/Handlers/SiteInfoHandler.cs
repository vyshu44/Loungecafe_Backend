using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class SiteInfoHandler
    {
        private readonly ILoungecafeRepository _repository;

        public SiteInfoHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<SiteInfoModel>> GetSiteInfoDataAsync()
        {
            var data = await _repository.GetSiteInfoDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table SiteInfo !!");
            }
            return data;
        }
    }
}

