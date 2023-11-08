using Flights.Data.Interfaces;
using Flights.Models;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data.DataServices
{
    public class DocumentDataService : IDocumentDataService
    {
        private readonly DefaultContext defaultContext;

        public DocumentDataService(DefaultContext _defaultContext)
        {
            defaultContext = _defaultContext;
        }

        public async Task<List<Document>> GetAllByPassenger(long passengerId)
        {
            try
            {
                return await defaultContext.Set<Document>().Where(d => d.PassengerId == passengerId).ToListAsync();
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
                var model = defaultContext.Set<Document>().FirstOrDefault(x => x.Id == id);
                if (model == null) return false;
                defaultContext.Set<Document>().Remove(model);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Document model)
        {
            try
            {
                var currentModel = await defaultContext.Documents.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (currentModel == null) return false;
                currentModel.Type = model.Type;
                currentModel.Number = model.Number;
                defaultContext.Set<Document>().Update(currentModel);
                var result = await defaultContext.SaveChangesAsync();
                return GetResult(result);
            }
            catch(Exception ex)
            {
                return false;
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

