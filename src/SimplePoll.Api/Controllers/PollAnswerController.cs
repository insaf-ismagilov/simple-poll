using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplePoll.Application;
using SimplePoll.Application.Contracts;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Entities;

namespace SimplePoll.Api.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/polls/answers")]
	public class PollAnswerController : ApiControllerBase
	{
		private readonly IPollAnswerService _pollAnswerService;

		public PollAnswerController(IPollAnswerService pollAnswerService)
		{
			_pollAnswerService = pollAnswerService;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(PollAnswer), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(int id)
		{
			var pollAnswer = await _pollAnswerService.GetByIdAsync(id);
			if (pollAnswer == null)
				return NotFound();

			return Ok(pollAnswer);
		}

		[HttpPost]
		[ProducesResponseType(typeof(PollAnswer), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Add(AddPollAnswerRequest request)
		{
			var result = await _pollAnswerService.AddAnswerAsync(request);

			return MakeResponse(result);
		}
	}
}