using System;
using Flights.Data.Interfaces;
using Flights.Models.DTOs;

namespace Flights.Models
{
	public class Ticket: IBaseModel
	{
		public long Id { get; set; }
		public string DeparturePoint { get; set; }
		public string Destination { get; set; }
		public string OrderNumber { get; set; }
		public string AirCarrier { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }
		public DateTime RegistrationDate { get; set; }

        public List<Passenger> Passengers { get; set; } = new();

		public Ticket()
		{
		}
	}
}

