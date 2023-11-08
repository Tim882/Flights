using System;
using Flights.Models;
using Flights.Models.DTOs;

namespace Flights.Data.Interfaces
{
	public interface IPassengerDataService
	{
        public Task<List<Passenger>> GetAllByTicket(long ticketId);
        public Task<bool> Delete(long id);
        public Task<bool> Update(Passenger model);
        public Task<List<ReportDTO>> GetReport(long passengerId, DateTime periodStartDate, DateTime periodEndDate);
    }
}

