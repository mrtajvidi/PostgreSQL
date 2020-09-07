using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgreSQL.Handlers;
using System.Threading.Tasks;

namespace PostgreSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DvdRentalController : ControllerBase
    {
        private readonly ILogger<DvdRentalController> _logger;
        private readonly DvdRentalHandler _dvdRentalHandler;

        public DvdRentalController(ILogger<DvdRentalController> logger, DvdRentalHandler dvdRentalHandler)
        {
            _logger = logger;
            _dvdRentalHandler = dvdRentalHandler;
        }

        [HttpGet("{actorId}")]
        public async Task<IActionResult> Get(int actorId)
        {
            var response = await _dvdRentalHandler.GetActorById(actorId);
            return Ok(response);
        }
    }
}