﻿using Microsoft.AspNetCore.Mvc;

using System;
using System.Security.Claims;
using System.Threading.Tasks;

using UniLink.API.Attributes;
using UniLink.API.Business.Interfaces;
using UniLink.Dependencies.Enums;
using UniLink.Dependencies.Models;

namespace UniLink.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly ICourseBusiness _courseBusiness;

		public CoursesController(ICourseBusiness courseBusiness)
		{
			_courseBusiness = courseBusiness;
		}

		[HttpGet]
		[Authorizes(UserTypeEnum.Coordinator)]
		public async Task<IActionResult> CourseByCoordIdTaskAsync()
		{
			var coordId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

			if (await _courseBusiness.FindByCoordIdTaskAsync(coordId) is CourseModel course)
				return Ok(course);

			return NotFound("Nao existe nenhum curso com este coordenador");
		}
	}
}