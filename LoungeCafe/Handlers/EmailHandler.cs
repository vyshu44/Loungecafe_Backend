using LoungeCafe.Models;
using LoungeCafe.Repositories;

namespace LoungeCafe.Handlers
{
    public class EmailHandler
    {
        private readonly ILoungecafeRepository _repository; 

        public EmailHandler(ILoungecafeRepository repo)
        {
            _repository = repo;
        }

        public async Task<List<EmailModel>> GetEmailDataAsync(EmailModel request)
        {
            var data = await _repository.GetEmailDataAsync(request);
            if (data == null || !data.Any())
            {
                throw new Exception("No data found in the table Email !!");
            }
            return data;
        }

    }
}
