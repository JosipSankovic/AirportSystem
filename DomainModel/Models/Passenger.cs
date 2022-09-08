using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public bool Checked { get; set; }
        public string? SeatNumber { get; set; }
        public int? NumberOfLuggage {get;set;}
        public int? LuggageWeight { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLastname { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime? DocumentExpirationDate { get; set; }
        public int? FlightId { get; set; }
        public Flight Flight { get; set; }

    }
}
