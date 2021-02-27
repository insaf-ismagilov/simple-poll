using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplePoll.Application.Contracts;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Api.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/polls")]
	public class PollsController : ApiControllerBase
	{
		private readonly IPollService _pollService;
		private readonly IPollPreviewService _pollPreviewService;

		public PollsController(
			IPollService pollService,
			IPollPreviewService pollPreviewService)
		{
			_pollService = pollService;
			_pollPreviewService = pollPreviewService;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _pollService.GetByIdAsync(id);
			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(ICollection<Poll>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll()
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

			return MakeResponse(result);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(int id, UpdatePollRequest request)
		{
			if (id != request.Id)
				return BadRequest();

			var result = await _pollService.UpdateAsync(request);

			return MakeResponse(result);
		}

		[HttpGet("{id}/preview")]
		[ProducesResponseType(typeof(Poll), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetByIdPreview(int id)
		{
			var pollPreview = await _pollPreviewService.GetByIdAsync(id);
			if (pollPreview == null)
				return NotFound();

			return Ok(pollPreview);
		}
	}
}