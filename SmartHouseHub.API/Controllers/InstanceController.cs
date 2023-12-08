using Affiliates.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using SmartHouseHub.API.Dto;
using SmartHouseHub.API.Interfaces;

namespace SmartHouseHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InstanceController : Controller
	{
		private readonly IInstanceService _instanceService;
		private readonly ILogService _logService;

		public InstanceController(IInstanceService instanceService, ILogService logService)
		{
			_instanceService = instanceService;
			_logService = logService;
		}

		[HttpGet("")]
		public async Task<List<InstanceDto>> GetAll()
		{
			try
			{
				return await _instanceService.GetAll();
			}
			catch (Exception ex)
			{
			 	await _logService.Insert(new()
				{
					Id = Guid.NewGuid(),
					Message = ex.Message,
					Type = LogType.Error,
					Timestamp = DateTime.UtcNow,
				});

				throw;
			}
		}

		[HttpGet("{id}")]
		public async Task<InstanceDto> GetById(Guid id)
		{
			try
			{
				return await _instanceService.GetById(id);
			}
			catch (Exception ex)
			{
				await _logService.Insert(new()
				{
					Id = Guid.NewGuid(),
					Message = ex.Message,
					Type = LogType.Error,
					Timestamp = DateTime.UtcNow,
				});

				throw;
			}
		}

		/// <summary>
		/// Delete all documents inside collection. Returns how many documents was deleted.
		/// </summary>
		/// <returns></returns>
		[HttpDelete("")]
		public async Task<int> DeleteAll()
		{
			try
			{
				return await _instanceService.DeleteAll();
			}
			catch (Exception ex)
			{
				await _logService.Insert(new()
				{
					Id = Guid.NewGuid(),
					Message = ex.Message,
					Type = LogType.Error,
					Timestamp = DateTime.UtcNow,
				});

				throw;
			}
		}

		[HttpDelete("{id}")]
		public async Task<DeleteDto> DeleteById(Guid id)
		{
			try
			{
				return await _instanceService.DeleteById(id);
			}
			catch (Exception ex)
			{
				await _logService.Insert(new()
				{
					Id = Guid.NewGuid(),
					Message = ex.Message,
					Type = LogType.Error,
					Timestamp = DateTime.UtcNow,
				});

				throw;
			}
		}

		[HttpPost("")]
		public async Task<InstanceDto> Insert([FromBody] InstanceDto obj)
		{
			try
			{
				return await _instanceService.Insert(obj);
			}
			catch (Exception ex)
			{
				await _logService.Insert(new()
				{
					Id = Guid.NewGuid(),
					Message = ex.Message,
					Type = LogType.Error,
					Timestamp = DateTime.UtcNow,
				});

				throw;
			}
		}
	}
}