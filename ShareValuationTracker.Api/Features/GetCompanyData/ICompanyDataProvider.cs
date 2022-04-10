using HtmlAgilityPack;

namespace Placeholder.API.Features.GetCompanyData
{
    public interface ICompanyDataProvider
    {
        string GetPreviousCloseSharePrice(HtmlDocument document);
        string GetEarningsPerShare(HtmlDocument document);
    }
}
