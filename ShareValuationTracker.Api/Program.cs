using Placeholder.API.Adapters.DIExtensions;
using Placeholder.API.Features.GetCompanyData.DIExtensions;
using Placeholder.API.Services.Http.DIExtensions;
using Placeholder.API.Services.YahooFinance.DIExtensions;
using ShareValuationTracker.Api.Features.CalculateDiscountedCashFlow.DIExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator(o => o.AddHandlersFromAssemblyOf<Program>());

builder.Services.AddYahooFinanceClient();
builder.Services.AddHttpClient("YahooFinance", options => options.BaseAddress = new Uri("https://au.finance.yahoo.com/"));

builder.Services.AddHttp();
builder.Services.AddAdapters();

builder.Services.AddGetCompaniesFeature();
builder.Services.AddCalculateDiscountedCashFlowFeature();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
