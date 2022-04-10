using HtmlAgilityPack;

namespace Placeholder.API.Features.GetCompanyData
{
    public interface IYahooFinanceDataSelector
    {
        string GetMarketCapitalizationFromSummaryStream(HtmlDocument document);
        string GetPreviousCloseSharePriceFromSummaryStream(HtmlDocument document);
        string GetEarningsPerShareFromSummaryStream(HtmlDocument document);
        string GetFreeCashFlowTrailingTwelveMonthsFromCashFlowStream(HtmlDocument document);
        string GetProjectedGrowthRatePercentageFromAnalysisStream(HtmlDocument document);
    }
}
