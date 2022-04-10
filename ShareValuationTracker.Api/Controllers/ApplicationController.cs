using Microsoft.AspNetCore.Mvc;
using Placeholder.API.Features.GetCompanyData.Commands;
using SimpleSoft.Mediator;

namespace Placeholder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("companies")]
        public async Task<IActionResult> GetCompanyData(CancellationToken ct) 
        {
            return Ok(await _mediator.SendAsync(new GetCompanyDataCommand(), ct));
        }
    }
}

