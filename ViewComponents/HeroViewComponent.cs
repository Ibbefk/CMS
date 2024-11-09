using ibrahimcmsuppgift.Models;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ibrahimcmsuppgift.ViewComponents;

public class HeroViewComponent : ViewComponent
{
	private readonly IPublishedContentQuery _contentQuery;

	public HeroViewComponent(IPublishedContentQuery contentQuery)
	{
		_contentQuery = contentQuery;
	}

	public IViewComponentResult Invoke()
	{

		var homePage = _contentQuery.ContentAtRoot().OfType<HomePage>().FirstOrDefault();


		var heroViewModel = new HeroViewModel
		{
			Title = homePage.HeroTitle,
			Subtitle = homePage.HeroDescription,
			ImageUrl = homePage.HeroImage?.Url(),
			ButtonText = homePage.HeroButtonText
		};

		return View(heroViewModel);
	}
}
