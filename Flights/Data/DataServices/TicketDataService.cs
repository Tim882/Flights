using System;
using Flights.Data.Interfaces;
using Flights.Models;
using Flights.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data.DataServices
{
    public class TicketDataService : ITicketDataService
    {
        private readonly DefaultContext defaultContext;

        public TicketDataService(DefaultContext _defaultContext)
        {
            defaultContext = _defaultContext;
        }

        public async Task<bool> Create(Ticket model)
        {
            try
            {
                defaultContext.Set<Ticket>().Add(model);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Ticket>> GetAll()
        {
            try
            {
                return await defaultContext.Set<Ticket>().ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Ticket> GetItem(int id)
        {
            try
            {
                return await defaultContext.Set<Ticket>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = defaultContext.Set<Ticket>().FirstOrDefault(x => x.Id == id);
                defaultContext.Set<Ticket>().Remove(model);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Ticket model)
        {
            try
            {
                var currentModel = await defaultContext.Tickets.FirstOrDefaultAsync(x => x.Id == model.Id);
                currentModel.DeparturePoint = model.DeparturePoint;
                currentModel.Destination = model.Destination;
                currentModel.OrderNumber = model.OrderNumber;
                currentModel.AirCarrier = model.AirCarrier;
                currentModel.DepartureDate = model.DepartureDate;
                currentModel.ArrivalDate = model.ArrivalDate;
                currentModel.RegistrationDate = model.RegistrationDate;
                defaultContext.Set<Ticket>().Update(currentModel);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Ticket>> GetFullTicketInfo(long ticketId)
        {
            try
            {
                return await defaultContext.Set<Ticket>().Include(t => t.Passengers)
                    .ThenInclude(p => p.Select(d => d.Documents)).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool GetResult(int result)
        {
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

