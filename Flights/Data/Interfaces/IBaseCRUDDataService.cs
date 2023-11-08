using System;
namespace Flights.Data.Interfaces
{
	public interface IBaseCRUDDataService<T> where T: class, IBaseModel
	{
		public Task<bool> Create(T model);
		public Task<T> GetItem(int id);
		public Task<List<T>> GetAll();
		public Task<bool> Delete(int id);
		public Task<bool> Update(T model);
	}
}

