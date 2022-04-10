using HtmlAgilityPack;

namespace Placeholder.API.Features.GetCompanyData
{
    public class CompanyDataProvider : ICompanyDataProvider
    {
        public string GetPreviousCloseSharePrice(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.PreviousCloseSharePrice);

            return divs[0].InnerHtml;
        }

        public string GetEarningsPerShare(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.EarningsPerShare);

            return divs[7].InnerHtml;
        }
    }
}
