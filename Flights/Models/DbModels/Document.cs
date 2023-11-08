using System;
using Flights.Data.Interfaces;
using Flights.Models.DTOs;

namespace Flights.Models
{
	public class Document: IBaseModel
	{
        public long Id { get; set; }
        public DocumentType Type { get; set; }
		public string Number { get; set; }
		public long PassengerId { get; set; }
		public Passenger Passenger { get; set; }

        public Document()
		{
		}
	}
}

