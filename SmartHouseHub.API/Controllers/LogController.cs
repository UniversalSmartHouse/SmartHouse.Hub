using Affiliates.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using SmartHouseHub.API.Dto;
using SmartHouseHub.API.Interfaces;

namespace SmartHouseHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LogController : Controller
    {
        public readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet("")]
        public async Task<List<LogDto>> GetAll()
        {
            try
            {
                return await _logService.GetAll();
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
                return await _logService.DeleteById(id);
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
                return await _logService.DeleteAll();
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
		public async Task<LogDto> Insert([FromBody] LogDto obj)
		{
			try
			{
				return await _logService.Insert(obj);
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
