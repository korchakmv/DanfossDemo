using System;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Application.Homes;
using DanfossHomeTrackingService.Domain;
using DanfossHomeTrackingService.Query.Contracts.Homes;
using DanfossHomeTrackingService.Query.Contracts.Homes.Dtos;
using DanfossHomeTrackingService.Query.Contracts.Homes.Queries;
using DanfossHomeTrackingService.WebApi.Infrastructure;
using DanfossHomeTrackingService.WebApi.Mappers;
using DanfossHomeTrackingService.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DanfossHomeTrackingService.WebApi.Controllers
{
    [ApiController]
    [Route("api/homes")]
    public class HomesController : Controller
    {
        private readonly IMediator _mediator;

        public HomesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<HomeDto[]> GetAll() => 
            await _mediator.Send(new GetAllQuery());

        [HttpGet("{id}")]
        public async Task<HomeDto> GetById([FromRoute] int id) =>
            await _mediator.Send(new GetByIdQuery {Id = id});

        [HttpPut]
        public async Task<IActionResult> Create([FromBody] CreateHomeRequest request) =>
            Ok(await _mediator.Send(request));

        [HttpPost("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Models.EditHomeRequest request) =>
            Ok(await _mediator.Send(request.ToApplicationRequest(id)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) =>
            Ok(await _mediator.Send(new DeleteHomeRequest {Id = id}));

        [HttpPut("{id}/sensors")]
        public async Task<IActionResult> AddSensor([FromRoute] int id, [FromBody] Models.AddSensorRequest request) =>
            Ok(await _mediator.Send(request.ToApplicationRequest(id)));

        [HttpPut("{id}/sensors/{serial}/values")]
        public async Task<IActionResult> AddValueByHome([FromRoute] int id, [FromRoute] string serial,
            [FromBody] Models.AddSensorValueByHomeRequest request) =>
            Ok(await _mediator.Send(request.ToApplicationRequest(id, serial)));


        // [HttpPut]
        // public async Task<IActionResult> Create([FromBody] CreateHomeRequest request)
        // {
        //     if (string.IsNullOrEmpty(request.Address))
        //         return await Task.FromResult(BadRequest("Address is required"));
        //     
        //     var home = new Home(request.Address);
        //     
        //     await _db.Homes.AddAsync(home);
        //     await _db.SaveChangesAsync();
        //
        //     return Ok(home.Id);
        // }
    }
}