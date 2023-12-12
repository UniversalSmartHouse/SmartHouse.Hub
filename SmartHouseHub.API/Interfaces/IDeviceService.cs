using Affiliates.API.DTOs;
using SmartHouseHub.API.Dto;

namespace SmartHouseHub.API.Interfaces
{
	public interface IDeviceService
	{
		Task<List<DeviceDto>> GetAll();
		Task<DeviceDto> GetById(Guid id);
		Task<DeleteDto> DeleteById(Guid id);
		/// <summary>
		/// Delete all documents inside collection. Returns how many documents was deleted.
		/// </summary>
		/// <returns></returns>
		Task<int> DeleteAll();
		Task<DeviceDto> Insert(DeviceDto obj);
	}
}
