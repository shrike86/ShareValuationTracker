using Placeholder.API.Features.GetCompanyData.Commands;
using Placeholder.API.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Queries
{
    public class GetCompanyDataQueryHandler : IQueryHandler<GetCompanyDataQuery, List<Company>>
    {
        private readonly IMediator _mediator;

        public GetCompanyDataQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<Company>> HandleAsync(GetCompanyDataQuery query, CancellationToken ct)
        {
            // Get asx 200 companies.
            // foreach asx 200 company
            foreach (var company in Constants.Companies.Asx)
            {
                var summaryData = await _mediator.SendAsync(new GetYahooFinanceSummaryDataCommand { StockCode = company.StockCode}, ct);
            }

            // Check that the company has earnings
            // Check that the company has a positive 5 year projected growth rate
            // If true add to filtered list

            // foreach company in filtered list
            // get the ratio data
            // return the list


            return new List<Company>()
            {
                new Company
                {

                    Name = "Test"
                }
            };
        }
    }
}
