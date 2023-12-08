using Affiliates.API.DTOs;
using SmartHouseHub.API.Dto;

namespace SmartHouseHub.API.Interfaces
{
	public interface IInstanceService
	{
		Task<List<InstanceDto>> GetAll();
		Task<InstanceDto> GetById(Guid id);
		Task<DeleteDto> DeleteById(Guid id);
		Task<InstanceDto> Insert(InstanceDto obj);
	}
}
