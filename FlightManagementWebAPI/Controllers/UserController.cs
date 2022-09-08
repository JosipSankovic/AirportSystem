using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("GetUser")]
        public IActionResult GetUser([FromBody] User user)
        {
            try
            {  
                var use = _userRepository.GetUser(user);

                if (use != null &&use.isAdmin==true)
                {
                    return Ok("Admin");
                }
                else if (use != null && use.isAdmin == false)
                {
                    return Ok("CheckIn");
                }
                else return BadRequest();
                
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            try
            {
                _userRepository.InsertUser(user);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
