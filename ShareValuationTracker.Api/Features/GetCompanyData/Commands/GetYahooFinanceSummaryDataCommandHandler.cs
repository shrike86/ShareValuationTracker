using HtmlAgilityPack;
using Placeholder.API.Features.GetCompanyData.Models;
using Placeholder.API.Services.Yahoo;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceSummaryDataCommandHandler : ICommandHandler<GetYahooFinanceSummaryDataCommand, YahooFinanceSummaryData>
    {
        private readonly IYahooFinanceService _yahooFinanceService;
        private readonly IYahooFinanceDataSelector _companyDataProvider;

        public GetYahooFinanceSummaryDataCommandHandler(
            IYahooFinanceService yahooFinanceService, 
            IYahooFinanceDataSelector companyDataProvider)
        {
            _yahooFinanceService = yahooFinanceService;
            _companyDataProvider = companyDataProvider;
        }


        public async Task<YahooFinanceSummaryData> HandleAsync(GetYahooFinanceSummaryDataCommand cmd, CancellationToken ct)
        {
            var summaryStream = await _yahooFinanceService.GetYahooSummaryStreamByCompany(cmd.StockCode);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(summaryStream);

            return new YahooFinanceSummaryData 
            {
                PreviousCloseSharePrice = _companyDataProvider.GetPreviousCloseSharePriceFromSummaryStream(htmlDoc),
                EarningsPerShare = _companyDataProvider.GetEarningsPerShareFromSummaryStream(htmlDoc)
            };
        }
    }
}
