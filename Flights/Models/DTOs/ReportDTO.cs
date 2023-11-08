using System;
namespace Flights.Models.DTOs
{
	public class ReportDTO
	{
        public DateTime RegistrationDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string OrderNumber { get; set; }
        public string DeparturePoint { get; set; }
        public string Destination { get; set; }
        public bool Completed { get; set; }

        public ReportDTO()
		{
		}
	}
}

