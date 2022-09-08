using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Models;

namespace FlightManagementWebAPI.Repositories
{
    public class PassengerRepository
    {
        private readonly AirportSystemContext _airportSystemContext;


        public PassengerRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public Passenger GetPassenger(int passengerId)
        {
            return _airportSystemContext.Passengers.FirstOrDefault(pass => pass.Id.Equals(passengerId));
        }

        public List<Passenger> GetCheckedPassengers(int flightId) {

            return _airportSystemContext.Passengers.Where(passenger => passenger.Checked.Equals(true)).Where(passenger=>passenger.FlightId.Equals(flightId)).ToList();
        
        }
        public void AddPassengerToFlight(Passenger passenger)
        {
            _airportSystemContext.Passengers.Add(passenger);
            _airportSystemContext.SaveChanges();
        }

        public List<Passenger> GetPassengers(int flightId)
        {
           return _airportSystemContext.Passengers.Where(pass => pass.FlightId.Equals(flightId)).ToList();
           
        }

        public void DeletePassenger(int passengertId)
        {
            var passenger = GetPassenger(passengertId);

            _airportSystemContext.Passengers.Remove(passenger);
            _airportSystemContext.SaveChanges();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            var passengerToUpdate = GetPassenger(passenger.Id);

            if (passengerToUpdate != null)
            {
                passengerToUpdate.Name = passenger.Name;
                passengerToUpdate.Lastname = passenger.Lastname;
                passengerToUpdate.Gender=passenger.Gender;
                passengerToUpdate.LuggageWeight = passenger.LuggageWeight;
                passengerToUpdate.NumberOfLuggage = passenger.NumberOfLuggage;
                passengerToUpdate.DocumentExpirationDate = passenger.DocumentExpirationDate;
                passengerToUpdate.DocumentLastname = passenger.DocumentLastname;
                passengerToUpdate.DocumentName = passenger.DocumentName;
                passengerToUpdate.DocumentNumber = passenger.DocumentNumber;
                passengerToUpdate.DocumentType = passenger.DocumentType;
            }
            _airportSystemContext.SaveChanges();
        }

        public void CheckInPassenger(Passenger passenger)
        {
            var passengerToCheckIn = GetPassenger(passenger.Id);
            if (passengerToCheckIn != null)
            {
                passengerToCheckIn.Checked = passenger.Checked;
                passengerToCheckIn.SeatNumber = passenger.SeatNumber;
                passengerToCheckIn.NumberOfLuggage = passenger.NumberOfLuggage;
                passengerToCheckIn.LuggageWeight = passenger.LuggageWeight;
                passengerToCheckIn.DocumentName = passenger.DocumentName;
                passengerToCheckIn.DocumentLastname = passenger.DocumentLastname;
                passengerToCheckIn.DocumentType = passenger.DocumentType;
                passengerToCheckIn.DocumentNumber = passenger.DocumentNumber;
                passengerToCheckIn.DocumentExpirationDate = passenger.DocumentExpirationDate;


            }
            _airportSystemContext.SaveChanges();
        }

        public void CheckOutPassenger(int passengerId)
        {
            var passengerToCheckOut = GetPassenger(passengerId);
            if (passengerToCheckOut != null)
            {
                passengerToCheckOut.Checked = false;
                passengerToCheckOut.SeatNumber = null;
            }

            _airportSystemContext.SaveChanges();
        }
    }
}
