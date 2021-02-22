using Microsoft.AspNetCore.Mvc;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Api.Controllers
{
	public abstract class ApiControllerBase : ControllerBase
	{
		protected IActionResult Response<T>(ServiceResponse<T> serviceResponse)
		{
			if (!serviceResponse.Successful)
				return BadRequest(serviceResponse.ErrorMessage);

			if (serviceResponse.Data == null)
				return NotFound();
			
			return Ok(serviceResponse.Data);
		}
		
		protected IActionResult Response(ServiceResponse serviceResponse)
		{
			if (!serviceResponse.Successful)
				return BadRequest(serviceResponse.ErrorMessage);
			
			return Ok();
		}
	}
}