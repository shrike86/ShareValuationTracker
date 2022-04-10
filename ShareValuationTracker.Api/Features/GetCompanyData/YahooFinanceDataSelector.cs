using HtmlAgilityPack;

namespace Placeholder.API.Features.GetCompanyData
{
    public class YahooFinanceDataSelector : IYahooFinanceDataSelector
    {
        public string GetMarketCapitalizationFromSummaryStream(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.MarketCapitalization);

            return divs?[1].InnerHtml ?? "";
        }

        public string GetPreviousCloseSharePriceFromSummaryStream(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.PreviousCloseSharePrice);

            return divs?[0].InnerHtml ?? "";
        }

        public string GetEarningsPerShareFromSummaryStream(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.EarningsPerShare);

            return divs?[7]?.InnerHtml ?? "";
        }

        public string GetFreeCashFlowTrailingTwelveMonthsFromCashFlowStream(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.FreeCashFlowTrailingTwelveMonths);

            return divs?.Last()?.ChildNodes.First()?.ChildNodes[1]?.InnerText ?? "";
        }

        public string GetProjectedGrowthRatePercentageFromAnalysisStream(HtmlDocument document)
        {
            var tableBodies = document.DocumentNode.SelectNodes(Constants.YahooMarketXPaths.ProjectedGrowthRatePercentage);

            return tableBodies?.Last()?.ChildNodes[4].ChildNodes[1]?.InnerText ?? "";
        }
    }
}
