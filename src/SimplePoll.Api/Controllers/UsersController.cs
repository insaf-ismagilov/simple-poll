﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplePoll.Api.Models;
using SimplePoll.Application;
using SimplePoll.Application.Contracts;

namespace SimplePoll.Api.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/users")]
	public class UsersController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public UsersController(
			IUserService userService,
			IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(UserVm), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var result = await _userService.GetByIdAsync(id);

			if (result == null)
				return NotFound();

			return Ok(_mapper.Map<UserVm>(result));
		}
	}
}