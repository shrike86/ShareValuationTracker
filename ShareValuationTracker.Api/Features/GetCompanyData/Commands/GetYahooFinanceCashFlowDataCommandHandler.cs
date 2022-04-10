using Placeholder.API.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceCashFlowDataCommandHandler : ICommandHandler<GetYahooFinanceCashFlowDataCommand, YahooFinanceCashflowData>
    {
        public Task<YahooFinanceCashflowData> HandleAsync(GetYahooFinanceCashFlowDataCommand cmd, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
