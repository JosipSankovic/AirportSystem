using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : Controller
    {
        readonly PassengerRepository _passengerRepository;

        public PassengerController(PassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpPost]
        public IActionResult AddPassenger([FromBody] Passenger passenger)
        {
            try
            {
                if (passenger != null)
                {
                    _passengerRepository.AddPassengerToFlight(passenger);
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }
        }

        [HttpGet("{flightId:int}")]
        public IActionResult GetPassengers(int flightId)
        {
            try
            {

                return Ok(_passengerRepository.GetPassengers(flightId));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetPassenger/{passengerId:int}")]
        public IActionResult GetPassenger(int passengerId)
        {
            try
            {
                var passenger = _passengerRepository.GetPassenger(passengerId);
                return Ok(passenger);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("GetCheckedPassengers/{flightId:int}")]
        public IActionResult GetCheckedPassengers(int flightId)
        {
            try
            {
                var passengers = _passengerRepository.GetCheckedPassengers(flightId);
                return Ok(passengers);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{passengerId:int}")]
        public IActionResult DeletePassenger(int passengerId)
        {
            try
            {
                _passengerRepository.DeletePassenger(passengerId);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdatePassenger([FromBody] Passenger passenger)
        {
            try
            {
                if (passenger != null)
                {
                    _passengerRepository.UpdatePassenger(passenger);
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        

        [HttpPut("CheckInPassenger")]
        public IActionResult CheckInPassenger([FromBody] Passenger passenger)
        {
            try
            {
                _passengerRepository.CheckInPassenger(passenger);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("CheckOutPassenger/{passengerId:int}")]
        public IActionResult CheckInPassenger(int passengerId)
        {
            try
            {
                _passengerRepository.CheckOutPassenger(passengerId);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
