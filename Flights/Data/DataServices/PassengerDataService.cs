using Flights.Data.Interfaces;
using Flights.Models;
using Flights.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data.DataServices
{
    public class PassengerDataService : IPassengerDataService
    {
        private readonly DefaultContext defaultContext;

        public PassengerDataService(DefaultContext _defaultContext)
        {
            defaultContext = _defaultContext;
        }

        public async Task<List<Passenger>> GetAllByTicket(long ticketId)
        {
            try
            {
                return await defaultContext.Set<Passenger>().Where(p => p.Tickets.Select(t => t.Id).Contains(ticketId)).ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var model = await defaultContext.Set<Passenger>().FirstOrDefaultAsync(x => x.Id == id);
                if (model == null) return false;
                defaultContext.Set<Passenger>().Remove(model);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Passenger model)
        {
            try
            {
                var currentModel = await defaultContext.Passengers.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (currentModel == null) return false;
                currentModel.Name = model.Name;
                currentModel.Surname = model.Surname;
                currentModel.MiddleName = model.MiddleName;
                defaultContext.Set<Passenger>().Update(currentModel);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ReportDTO>> GetReport(long passengerId, DateTime periodStartDate, DateTime periodEndDate)
        {
            try
            {
                var report = await defaultContext.Set<Ticket>().Include(t => t.Passengers)
                    .Where(t => t.Passengers.Select(p => p.Id).Contains(passengerId))
                    .Where(t => (t.DepartureDate.Date >= periodStartDate.Date
                    && t.ArrivalDate.Date <= periodEndDate.Date)
                    || (t.RegistrationDate.Date >= periodStartDate.Date
                    && t.RegistrationDate.Date <= periodEndDate.Date))
                    .Select(t => new ReportDTO {
                        RegistrationDate = t.RegistrationDate,
                        DepartureDate = t.DepartureDate,
                        OrderNumber = t.OrderNumber,
                        DeparturePoint = t.DeparturePoint,
                        Destination = t.Destination,
                        Completed = t.ArrivalDate <= DateTime.Now
                    }).ToListAsync();

                return report;
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

