using ibrahimcmsuppgift.Models;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;

namespace ibrahimcmsuppgift.ViewComponents;

public class NavBarViewComponent : ViewComponent
{
	private readonly IPublishedContentQuery _contentQuery;

	public NavBarViewComponent(IPublishedContentQuery contentQuery)
	{
		_contentQuery = contentQuery;
	}

	public IViewComponentResult Invoke()
	{
		var rootContent = _contentQuery.ContentAtRoot().FirstOrDefault();

		if (rootContent == null)
		{
			return Content("No root content found.");
		}

		var navItems = rootContent.Children
			.Where(c => c.IsVisible())
			.Select(c => new NavBarViewModel
			{
				Title = c.Name,
				Url = c.Url()
			})
			.ToList();

		return View(navItems);
	}
}

