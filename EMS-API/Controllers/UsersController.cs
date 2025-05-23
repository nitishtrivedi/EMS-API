﻿using EMS_API.Data;
using EMS_API.Models;
using EMS_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace EMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound(new { Message = $"User with ID: {id} not found" });
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newUser = await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser([FromBody] UserModel user, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != user.Id) return BadRequest(new { Message = "User ID mismatch" });
            var success = await _userService.EditUser(user, id);
            if (!success) return NotFound(new { Message = $"User with ID: {id} not found." });
            return Ok(new { Message = $"User with ID: {id} modified successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUser(id);
            if (!success) return BadRequest(new { Message = $"user with ID: {id} not found." });
            return Ok(new { Message = "User Deleted successfully" });
        }
    }
}
