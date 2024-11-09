using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ibrahimcmsuppgift.Controllers;
public class AboutUsPageController : RenderController
{
	public AboutUsPageController(ILogger<AboutUsPageController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{
	}

	public override IActionResult Index()
	{

		return CurrentTemplate(CurrentPage);
	}
}
