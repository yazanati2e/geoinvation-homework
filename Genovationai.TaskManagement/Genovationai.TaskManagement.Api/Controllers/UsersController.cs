using Genovationai.TaskManagement.Api.Dtos;
using Genovationai.TaskManagement.Core.Abstraction;
using Genovationai.TaskManagement.Core.Abstraction.Services;
using Genovationai.TaskManagement.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Genovationai.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Developer")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = await _usersService.GetByIdAsync(id);

            if (record is null)
            {
                return NotFound();
            }

            return Ok(new TeamMemberDto(record));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var records = await _usersService.GetAllAsync();

            if (records is null || !records.Any())
            {
                return NotFound();
            }

            var data = new List<TeamMemberDto>();
            foreach (var record in records)
            {
                data.Add(new TeamMemberDto(record));
            }

            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamMemberDto userDto)
        {
            var addedUserRecord = await _usersService.CreateAsync(new TeamMember() { FirstName = userDto.FirstName, LastName = userDto.LastName });


            return CreatedAtAction(nameof(Get), new { id = addedUserRecord.Id }, new TeamMemberDto(addedUserRecord));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTeamMemberDto userDto)
        {
            var existingUser = await _usersService.UpdateAsync(new TeamMember() {Id = userDto.Id, FirstName = userDto.FirstName, LastName = userDto.LastName });
            if (existingUser is null)
            {
                return NotFound();
            }


            return Ok(new TeamMemberDto(existingUser));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _usersService.DeleteAsync(id);
            if(success)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
