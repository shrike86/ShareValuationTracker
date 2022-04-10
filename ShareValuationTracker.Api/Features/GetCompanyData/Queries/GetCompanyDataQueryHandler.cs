using ShareValuationTracker.Api.Features.GetCompanyData;
using ShareValuationTracker.Api.Features.GetCompanyData.Commands;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Queries
{
    public class GetCompanyDataQueryHandler : IQueryHandler<GetCompanyDataQuery, List<CompanyData>>
    {
        private readonly IMediator _mediator;
        private readonly ICompanyDataSelector _companyDataSelector;

        public GetCompanyDataQueryHandler(
            IMediator mediator, 
            ICompanyDataSelector companyDataSelector)
        {
            _mediator = mediator;
            _companyDataSelector = companyDataSelector;
        }

        public async Task<List<CompanyData>> HandleAsync(GetCompanyDataQuery query, CancellationToken ct)
        {
            var companyData = new List<CompanyData>();

            foreach (var company in Constants.Companies.Asx)
            {
                var yahooFinanceData = await _mediator.SendAsync(new GetYahooFinanceDataCommand { StockCode = company.StockCode }, ct);

                companyData.Add(_companyDataSelector.Select(company, yahooFinanceData));
            }

            return companyData;
        }
    }
}
