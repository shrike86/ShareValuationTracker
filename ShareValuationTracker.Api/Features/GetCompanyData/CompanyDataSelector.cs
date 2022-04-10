using Placeholder.API.Features.GetCompanyData.Models;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;

namespace ShareValuationTracker.Api.Features.GetCompanyData
{
    public class CompanyDataSelector : ICompanyDataSelector
    {
        public CompanyData Select(Company company, YahooFinanceData yahooFinanceData)
        {
            return new CompanyData
            {
                Name = company.Name,
                StockCode = company.StockCode,
                EarningsPerShare = yahooFinanceData.EarningsPerShare,
                PreviousCloseSharePrice = yahooFinanceData.PreviousCloseSharePrice,
                FreeCashFlowTrailingTwelveMonths = yahooFinanceData.FreeCashFlowTrailingTwelveMonths
            };
        }
    }
}
