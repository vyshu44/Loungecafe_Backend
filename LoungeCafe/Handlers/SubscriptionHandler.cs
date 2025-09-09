using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class SubscriptionHandler
    {
        private readonly ILoungecafeRepository _repository;

        public SubscriptionHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<SubscriptionModel>> GetSubscriptionDataAsync()
        {
            var data = await _repository.GetSubscriptionDataAsync();
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Subscription !!");
            }
            return data;
        }
    }
}
