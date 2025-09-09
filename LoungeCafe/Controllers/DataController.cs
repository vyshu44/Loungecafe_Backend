using LoungeCafe.Handlers;
using LoungeCafe.Models;
using Microsoft.AspNetCore.Mvc;
namespace LoungeCafe.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly NavLinksHandler _navLinksHandler;
        private readonly SiteInfoHandler _siteInfoHandler;
        private readonly ImagesHandler _imagesHandler;
        private readonly IntroHandler _introHandler;
        private readonly SocialMediaHandler _socialMediaHandler;
        private readonly AboutHandler _aboutHandler;
        private readonly CategoriesHandler _categoriesHandler;
        private readonly ProductsHandler _productsHandler;
        private readonly GalleryHandler _galleryHandler;
        private readonly ClientsHandler _clientsHandler;
        private readonly FooterHandler _footerHandler;
        private readonly IconsHandler _iconsHandler;
        private readonly AdditionalInfoHandler _additionalInfoHandler;
        private readonly SubscriptionHandler _subscriptionHandler;


        private readonly EmailHandler _emailHandler;
        public DataController(NavLinksHandler navLinksHandler,
                              SiteInfoHandler siteInfoHandler,
                              ImagesHandler imagesHandler,
                              IntroHandler introHandler,
                              SocialMediaHandler socialMediaHandler,
                              AboutHandler aboutHandler,
                              CategoriesHandler categoriesHandler,
                              ProductsHandler productsHandler,
                              GalleryHandler galleryHandler,
                              ClientsHandler clientsHandler,
                              FooterHandler footerHandler,
                              IconsHandler iconsHandler,
                              AdditionalInfoHandler additionalInfoHandler,
                              SubscriptionHandler subscriptionHandler,
                              EmailHandler emailHandler
                              )
        {
            _navLinksHandler = navLinksHandler;
            _siteInfoHandler = siteInfoHandler;
            _imagesHandler = imagesHandler;
            _introHandler = introHandler;
            _socialMediaHandler = socialMediaHandler;
            _aboutHandler = aboutHandler;
            _categoriesHandler = categoriesHandler;
            _productsHandler = productsHandler;
            _galleryHandler = galleryHandler;
            _clientsHandler = clientsHandler;
            _footerHandler = footerHandler;
            _iconsHandler = iconsHandler;
            _additionalInfoHandler = additionalInfoHandler;
            _subscriptionHandler = subscriptionHandler;
            _emailHandler = emailHandler;
        }

        [HttpGet("NavLinks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NavLinksModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetNavLinks()
        {
            var links = await _navLinksHandler.GetNavLinksDataAsync();
            return Ok(links);
        }

        [HttpGet("SiteInfo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SiteInfoModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetSiteInfo()
        {
            var info = await _siteInfoHandler.GetSiteInfoDataAsync();
            return Ok(info);
        }

        [HttpGet("Images")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ImagesModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetImages()
        {
            var image = await _imagesHandler.GetImagesDataAsync();
            return Ok(image);
        }


        [HttpGet("Intro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IntroModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetIntro()
        {
            var data = await _introHandler.GetIntroDataAsync();
            return Ok(data);
        }


        [HttpGet("SocialMedia")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SocialMediaModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetSocialMedia()
        {
            var data = await _socialMediaHandler.GetSocialMediaDataAsync();
            return Ok(data);
        }

        [HttpGet("About")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AboutModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetAbout()
        {
            var data = await _aboutHandler.GetAboutDataAsync();
            return Ok(data);
        }

        [HttpGet("Categories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoriesModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetCategories()
        {
            var data = await _categoriesHandler.GetCategoriesDataAsync();
            return Ok(data);
        }

        [HttpGet("Products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductsModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetProducts()
        {
            var data = await _productsHandler.GetProductsDataAsync();
            return Ok(data);
        }

        [HttpGet("Gallery")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GalleryModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetGallery()
        {
            var data = await _galleryHandler.GetGalleryDataAsync();
            return Ok(data);
        }

        [HttpGet("Clients")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClientsModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetClients()
        {
            var data = await _clientsHandler.GetClientsDataAsync();
            return Ok(data);
        }

        [HttpGet("Footer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FooterModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetFooter()
        {
            var data = await _footerHandler.GetFooterDataAsync();
            return Ok(data);
        }


        [HttpGet("Icons")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IconsModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetIcons()
        {
            var data = await _iconsHandler.GetIconsDataAsync();
            return Ok(data);
        }


        [HttpGet("AdditionalInfo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AdditionalInfoModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetAdditionalInfo()
        {
            var data = await _additionalInfoHandler.GetAdditionalInfoDataAsync();
            return Ok(data);
        }

        [HttpGet("Subscription")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubscriptionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> GetSubscription()
        {
            var data = await _subscriptionHandler.GetSubscriptionDataAsync();
            return Ok(data);
        }


        [HttpPost("Email")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmailModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]

        public async Task<IActionResult> PostEmail([FromBody] EmailModel request)
        {
            if (request == null)
            {
                return BadRequest(new ErrorModel { Message = "Request body is null." });
            }

            var message = await _emailHandler.GetEmailDataAsync(request);
            return Ok("Email has been stored Successfully" );
        }



    }
}

