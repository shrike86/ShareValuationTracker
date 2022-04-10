using Placeholder.API.Features.GetCompanyData.Models;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;

namespace ShareValuationTracker.Api.Features.GetCompanyData
{
    public interface ICompanyDataSelector
    {
        CompanyData Select(Company company, YahooFinanceData yahooFinanceData);
    }
}
