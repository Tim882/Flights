using System;
using Flights.Models;

namespace Flights.Data.Interfaces
{
	public interface IDocumentDataService
	{
        public Task<List<Document>> GetAllByPassenger(long passengerId);
        public Task<bool> Delete(long id);
        public Task<bool> Update(Document model);
    }
}

