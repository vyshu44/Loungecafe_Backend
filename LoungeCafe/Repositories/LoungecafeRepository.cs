using Dapper;
using LoungeCafe.Database;
using LoungeCafe.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoungeCafe.Repositories
{
    public class LoungecafeRepository : ILoungecafeRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public LoungecafeRepository(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }
        public async Task<List<NavLinksModel>> GetNavLinksDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetNavLinks]";
                    var result = await connection.QueryAsync<NavLinksModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Nav Links Data. \n error:{ex.Message}");
                throw;
            }
        }
        public async Task<List<SiteInfoModel>> GetSiteInfoDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetSiteInfo]";
                    var result = await connection.QueryAsync<SiteInfoModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Site Info Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<ImagesModel>> GetImagesDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetImages]";
                    var result = await connection.QueryAsync<ImagesModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Images Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<IntroModel>> GetIntroDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetIntro]";
                    var result = await connection.QueryAsync<IntroModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Intro Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<SocialMediaModel>> GetSocialMediaDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetSocialMedia]";
                    var result = await connection.QueryAsync<SocialMediaModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Social Media Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<AboutModel>> GetAboutDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetAbout]";
                    var result = await connection.QueryAsync<AboutModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching About Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<CategoriesModel>> GetCategoriesDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetCategories]";
                    var result = await connection.QueryAsync<CategoriesModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Categories Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<ProductsModel>> GetProductsDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetProducts]";
                    var result = await connection.QueryAsync<ProductsModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Products Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<GalleryModel>> GetGalleryDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetGallery]";
                    var result = await connection.QueryAsync<GalleryModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Gallery Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<ClientsModel>> GetClientsDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetClients]";
                    var result = await connection.QueryAsync<ClientsModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Clients Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<FooterModel>> GetFooterDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetFooter]";
                    var result = await connection.QueryAsync<FooterModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Footer Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<IconsModel>> GetIconsDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetIcons]";
                    var result = await connection.QueryAsync<IconsModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Icons Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<AdditionalInfoModel>> GetAdditionalInfoDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetAdditionalInfo]";
                    var result = await connection.QueryAsync<AdditionalInfoModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Additional Info Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<SubscriptionModel>> GetSubscriptionDataAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var query = "[dbo].[GetSubscription]";
                    var result = await connection.QueryAsync<SubscriptionModel>(query, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Subscription Data. \n error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<EmailModel>> GetEmailDataAsync(EmailModel request)
        {
            try
            {
                using (var connection = new SqlConnection(_ApplicationDbContext.ConnectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Email", request.Email);
                    parameters.Add("@CreatedBy", 1);

                    var query = "[dbo].[InsertVYS_Email]";

                    var result = await connection.QueryAsync<EmailModel>(query, parameters, commandType: CommandType.StoredProcedure);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while connecting DB & fetching Email Data. \n error:{ex.Message}");        
                throw;
            }
        } 
    }
}
