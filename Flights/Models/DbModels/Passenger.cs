using System;
using Flights.Data.Interfaces;
using Flights.Models.DTOs;

namespace Flights.Models
{
	public class Passenger: IBaseModel
	{
        public long Id { get; set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public string MiddleName { get; set; }
		public List<Document> Documents { get; set; } = new();
		public List<Ticket> Tickets { get; set; } = new();

        public Passenger()
		{
		}
	}
}

