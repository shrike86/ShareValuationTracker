using HtmlAgilityPack;

namespace Placeholder.API.Features.GetCompanyData
{
    public interface IYahooFinanceDataSelector
    {
        string GetPreviousCloseSharePriceFromSummaryStream(HtmlDocument document);
        string GetEarningsPerShareFromSummaryStream(HtmlDocument document);
        string GetFreeCashFlowTrailingTwelveMonthsFromCashFlowStream(HtmlDocument document);
    }
}
