using Placeholder.API.Features.GetCompanyData.Models;
using ShareValuationTracker.Api.Features.GetCompanyData;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using ShareValuationTracker.Api.Features.GetCompanyData.Queries;
using SimpleSoft.Mediator;
using System.Threading.Tasks.Dataflow;

namespace Placeholder.API.Features.GetCompanyData.Commands
{
    public class GetCompanyDataCommandHandler : ICommandHandler<GetCompanyDataCommand, List<CompanyData>>
    {
        private readonly IMediator _mediator;
        private readonly ICompanyDataSelector _companyDataSelector;

        public GetCompanyDataCommandHandler(
            IMediator mediator,
            ICompanyDataSelector companyDataSelector)
        {
            _mediator = mediator;
            _companyDataSelector = companyDataSelector;
        }

        public async Task<List<CompanyData>> HandleAsync(GetCompanyDataCommand query, CancellationToken ct)
        {
            var companyData = new List<CompanyData>();

            var options = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 10,
                BoundedCapacity = 100
            };
            
            var block = new ActionBlock<Company>(async company => 
            {
                var yahooFinanceData = await _mediator.FetchAsync(new GetYahooFinanceDataQuery { StockCode = company.StockCode }, ct);

                companyData.Add(await _companyDataSelector.SelectAsync(company, yahooFinanceData, ct));
            }, options);

            foreach (var company in Constants.Companies.Asx200)
            {
                await block.SendAsync(company);
            }

            block.Complete();
            await block.Completion;

            return companyData;
        }
    }
}
