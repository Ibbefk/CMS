using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;

public class HomePageViewModel : PublishedContentWrapped
{
	public HomePageViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
		: base(content, publishedValueFallback)
	{
	}

	public string HeroTitle { get; set; }
	public string HeroDescription { get; set; }
	public string HeroButtonText { get; set; }
	public string HeroImageUrl { get; set; }

	public string AboutUsTitle { get; set; }
	public IHtmlEncodedString AboutUsContent { get; set; }

	public string OurServicesTitle { get; set; }
	public IEnumerable<IPublishedContent> OurServicesList { get; set; }

	public string RecentProjectsTitle { get; set; }
	public IEnumerable<IPublishedContent> RecentProjectsList { get; set; }

	public string SuccessStoryTitle { get; set; }
	public string FooterText { get; set; }

}
