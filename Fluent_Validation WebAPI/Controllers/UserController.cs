using AutoMapper;
using Fluent_Validation_WebAPI.Core.Validations;
using Fluent_Validation_WebAPI.Data;
using Fluent_Validation_WebAPI.Dtos;
using Fluent_Validation_WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fluent_Validation_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
        private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		public UserController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		[HttpGet("AllUser")]
		public IActionResult GetAll()
		{
			return Ok(_context.Users.ToList());
		}


		[HttpGet("{id}")]
		public IActionResult GetUserById(int id)
		{

			var user = _context.Users.SingleOrDefault(u => u.Id == id);

			if (user is null)
				return NotFound();

			return Ok(user);
		}


		[HttpPost("CreateUser")]
		public IActionResult Creat(UserDto userDto)
		{
			UserValidation validations = new ();

			var validationResult = validations.Validate(userDto);

			if (!validationResult.IsValid)
				return BadRequest(validationResult.Errors);
		


			var user = _mapper.Map<User>(userDto);

			_context.Add(user);
			_context.SaveChanges();

			return Ok(user);
		}


		[HttpPut("{id}")]
		public IActionResult Update(int id,[FromBody]UserDto userDto)
		{
			if (userDto == null || id != userDto.Id)
	            return BadRequest();
			

			var existingUser = _context.Users.Find(id);

			if (existingUser is null)
				return NotFound();


			_mapper.Map(userDto, existingUser); //Source , Destination
			
			_context.SaveChanges();

			return NoContent();

		}

	}
}
