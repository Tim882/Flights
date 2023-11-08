using System;
using Flights.Models;

namespace Flights.Data.Interfaces
{
	public interface ITicketDataService
	{
        public Task<bool> Create(Ticket model);
        public Task<Ticket> GetItem(int id);
        public Task<List<Ticket>> GetAll();
        public Task<bool> Delete(int id);
        public Task<bool> Update(Ticket model);
        public Task<List<Ticket>> GetFullTicketInfo(long ticketId);
    }
}

