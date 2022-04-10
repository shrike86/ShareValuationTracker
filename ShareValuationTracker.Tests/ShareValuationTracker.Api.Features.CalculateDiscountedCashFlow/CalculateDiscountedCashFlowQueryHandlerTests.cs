using FluentAssertions;
using NUnit.Framework;
using ShareValuationTracker.Api.Features.CalculateDiscountedCashFlow.Queries;
using SimpleSoft.Mediator;
using System.Threading.Tasks;

namespace ShareValuationTracker.Tests.ShareValuationTracker.Api.Features.CalculateDiscountedCashFlow
{
    [TestFixture]
    public class CalculateDiscountedCashFlowQueryHandlerTests
    {
        private IQueryHandler<CalculateDiscountedCashFlowQuery, double> _queryHandler;

        [SetUp]
        public void SetupCalculateDiscountedCashFlowQueryHandler()
        {
            _queryHandler = new CalculateDiscountedCashFlowQueryHandler();
        }

        [TestCase(1, 86957)]
        [TestCase(2, 86957 + 77883)]
        [TestCase(3, 86957 + 77883 + 69756)]
        [TestCase(4, 86957 + 77883 + 69756 + 62477)]
        [TestCase(5, 86957 + 77883 + 69756 + 62477 + 55958)]
        public async Task HandleReturnsTheExpectedResult(int numberOfYears, int expected)
        {
            var query = new CalculateDiscountedCashFlowQuery
            {
                FreeCashFlowTrailingTwelveMonths = 100000,
                DefaultGrowthRatePercentage = "3",
                DefaultDiscountRate = 0.15m,
                DefaultNumberOfYears = numberOfYears
            };

            var actual = await _queryHandler.HandleAsync(query, new System.Threading.CancellationToken());

            actual.Should().Be(expected);
        }
    }
}
