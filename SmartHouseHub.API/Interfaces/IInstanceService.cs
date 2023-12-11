using Affiliates.API.DTOs;
using SmartHouseHub.API.DTOs;

namespace SmartHouseHub.API.Interfaces
{
	public interface IInstanceService
	{
		Task<List<InstanceDto>> GetAll();
		Task<InstanceDto> GetById(Guid id);
		Task<DeleteDto> DeleteById(Guid id);
		/// <summary>
		/// Delete all documents inside collection. Returns how many documents was deleted.
		/// </summary>
		/// <returns></returns>
		Task<int> DeleteAll();
		Task<InstanceDto> Insert(InstanceDto obj);
	}
}
