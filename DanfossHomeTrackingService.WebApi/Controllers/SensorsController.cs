using System;
using System.Threading.Tasks;
using DanfossHomeTrackingService.WebApi.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DanfossHomeTrackingService.WebApi.Controllers
{
    [ApiController]
    [Route("api/sensors")]
    public class SensorsController : Controller
    {
        private readonly IMediator _mediator;

        public SensorsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPut("{serial}/values")]
        public async Task<IActionResult> AddValue([FromRoute] string serial,
            [FromBody] Models.AddSensorValueBySensorRequest request) =>
            Ok(await _mediator.Send(request.ToApplicationRequest(serial)));
    }
}