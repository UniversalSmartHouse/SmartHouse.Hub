using Affiliates.API.DTOs;
using SmartHouseHub.API.DTOs;

namespace SmartHouseHub.API.Interfaces
{
	public interface ILogService
	{
		Task<List<LogDto>> GetAll();
		/// <summary>
		/// Delete all documents inside collection. Returns how many documents was deleted.
		/// </summary>
		/// <returns></returns>
		Task<int> DeleteAll();
		Task<DeleteDto> DeleteById(Guid id);
		Task<LogDto> Insert(LogDto obj);
	}
}
