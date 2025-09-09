using LoungeCafe.Models;

namespace LoungeCafe.Repositories
{
    public interface ILoungecafeRepository
    {
        Task<List<NavLinksModel>> GetNavLinksDataAsync();
        Task<List<SiteInfoModel>> GetSiteInfoDataAsync();                                           
        Task<List<ImagesModel>> GetImagesDataAsync();
        Task<List<IntroModel>> GetIntroDataAsync();
        Task<List<SocialMediaModel>> GetSocialMediaDataAsync();
        Task<List<AboutModel>> GetAboutDataAsync();
        Task<List<CategoriesModel>> GetCategoriesDataAsync();
        Task<List<ProductsModel>> GetProductsDataAsync();
        Task<List<GalleryModel>> GetGalleryDataAsync();
        Task<List<ClientsModel>> GetClientsDataAsync();
        Task<List<FooterModel>> GetFooterDataAsync();
        Task<List<IconsModel>> GetIconsDataAsync();
        Task<List<AdditionalInfoModel>> GetAdditionalInfoDataAsync();
        Task<List<SubscriptionModel>> GetSubscriptionDataAsync();
        Task<List<EmailModel>> GetEmailDataAsync(EmailModel request);
    }
}
