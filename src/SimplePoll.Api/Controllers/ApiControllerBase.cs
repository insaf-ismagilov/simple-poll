using Microsoft.AspNetCore.Mvc;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Api.Controllers
{
	public abstract class ApiControllerBase : ControllerBase
	{
		protected IActionResult MakeResponse<T>(ServiceResponse<T> serviceResponse)
		{
			if (!serviceResponse.Successful)
				return BadRequest(serviceResponse.ErrorMessage);

			if (serviceResponse.Data == null)
				return NotFound();
			
			return Ok(serviceResponse.Data);
		}
		
		protected IActionResult MakeResponse(ServiceResponse serviceResponse)
		{
			if (!serviceResponse.Successful)
				return BadRequest(serviceResponse.ErrorMessage);
			
			return Ok();
		}
	}
}