using Genovationai.TaskManagement.Api.Dtos;
using Genovationai.TaskManagement.Core.Abstraction;
using Genovationai.TaskManagement.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Genovationai.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        public IRepository<TeamMember> _userRepository;

        public UsersController(IRepository<TeamMember> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = await _userRepository.GetByIdAsync(id);

            if (record is null)
            {
                return NotFound();
            }

            return Ok(new TeamMemberDto(record));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var records = await _userRepository.GetAllAsync();

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
            var user = new TeamMember
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName
            };
            await _userRepository.AddAsync(user);
            await _userRepository.Save();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, new TeamMemberDto(user));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTeamMemberDto userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(userDto.Id);
            if (existingUser is null)
            {
                return NotFound();
            }
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            _userRepository.Update(existingUser);
            await _userRepository.Save();
            return Ok(new TeamMemberDto(existingUser));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }
            await _userRepository.DeleteAsync(existingUser.Id);
            await _userRepository.Save();
            return NoContent();
        }
    }
}
