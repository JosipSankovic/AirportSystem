using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class UserRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public UserRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public User GetUser(User user)
        {
            return _airportSystemContext.Users.FirstOrDefault(_user=>_user.Username.Equals(user.Username)&&_user.Password.Equals(user.Password));
        }

        public void InsertUser(User user)
        {
            _airportSystemContext.Users.Add(user);
            _airportSystemContext.SaveChanges();
        }
    }
}
