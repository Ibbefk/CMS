using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ibrahimcmsuppgift.Controllers;

public class HomePageController : RenderController
{
	private readonly IPublishedValueFallback _publishedValueFallback;

	public HomePageController(
		ILogger<HomePageController> logger,
		ICompositeViewEngine compositeViewEngine,
		IUmbracoContextAccessor umbracoContextAccessor,
		IPublishedValueFallback publishedValueFallback 
	)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{
		_publishedValueFallback = publishedValueFallback;
	}

	public override IActionResult Index()
	{
		var homePage = CurrentPage as HomePage;

		if (homePage == null)
		{
			return NotFound();
		}

		var model = new HomePageViewModel(CurrentPage, _publishedValueFallback)
		{
			HeroTitle = homePage.HeroTitle,
			HeroDescription = homePage.HeroDescription,
			HeroButtonText = homePage.HeroButtonText,
			HeroImageUrl = homePage.HeroImage?.Url(),

			AboutUsTitle = homePage.AboutUsTitle,
			AboutUsContent = homePage.AboutUsContent,

			OurServicesTitle = homePage.OurServicesTitle,
			OurServicesList = homePage.OurServicesList,

			RecentProjectsTitle = homePage.RecentProjectsTitle,
			RecentProjectsList = homePage.RecentProjectsContentPicker,

			SuccessStoryTitle = homePage.SuccessStoryTitle,
			FooterText = homePage.FooterText
		};

		return CurrentTemplate(model);
	} 
}
