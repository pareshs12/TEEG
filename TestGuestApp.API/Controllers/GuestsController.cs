using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuestApp.Application.Commands.AddGuest;
using TestGuestApp.Application.Commands.AddPhone;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Application.Queries.GetAllGuests;
using TestGuestApp.Application.Queries.GetGuestById;

namespace TestGuestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<AddPhoneDTO> _addPhoneValidator;
        private readonly IValidator<AddGuestDTO> _guestValidator;

        public GuestsController(IMediator mediator, IMapper mapper, 
            IValidator<AddPhoneDTO> addPhoneValidator, IValidator<AddGuestDTO> guestValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _addPhoneValidator = addPhoneValidator;
            _guestValidator = guestValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest([FromBody] AddGuestDTO guestDto)
        {
            var validationResult = await _guestValidator.ValidateAsync(guestDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var command = _mapper.Map<AddGuestCommand>(guestDto);

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return BadRequest("Failed to add guest.");
            }

            return Ok("Guest Created Succesfully!!");
        }

        [HttpPut("addPhone")]
        public async Task<IActionResult> AddPhone([FromBody] AddPhoneDTO addPhoneDto)
        {
            var validationResult = await _addPhoneValidator.ValidateAsync(addPhoneDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            var command = _mapper.Map<AddPhoneCommand>(addPhoneDto);

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok("Phone Number Added Succesfully!!");
            }

            return BadRequest("Failed to add phone number.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDTO>> GetGuestById(Guid id)
        {
            var result = await _mediator.Send(new GetGuestByIdQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GuestDTO>>> GetAllGuests()
        {
            var result = await _mediator.Send(new GetAllGuestsQuery());

            if (result == null || result.Count() == 0)
            {
                return NotFound("No guests found.");
            }

            return Ok(result);
        }
    }
}
