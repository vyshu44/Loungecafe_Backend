using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class IconsHandler
    {
        private readonly ILoungecafeRepository _repository;

        public IconsHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<IconsModel>> GetIconsDataAsync()
        {
            var data = await _repository.GetIconsDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Icons !!");
            }
            return data;
        }
    }
}
