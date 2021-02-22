using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplePoll.Domain.Contracts.Services;
using SimplePoll.Domain.Entities;
using SimplePoll.Domain.Requests;

namespace SimplePoll.Api.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/polls")]
	public class PollsController : ApiControllerBase
	{
		private readonly IPollService _pollService;

		public PollsController(IPollService pollService)
		{
			_pollService = pollService;
		}

		[HttpGet("id")]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _pollService.GetByIdAsync(id);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetById()
		{
			var result = await _pollService.GetAllAsync();

			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create(CreatePollRequest request)
		{
			var result = await _pollService.CreateAsync(request);

			return Response(result);
		}

		[HttpPut("id")]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(int id, UpdatePollRequest request)
		{
			if (id != request.Id)
				return BadRequest();

			var result = await _pollService.UpdateAsync(request);

			return Response(result);
		}
	}
}