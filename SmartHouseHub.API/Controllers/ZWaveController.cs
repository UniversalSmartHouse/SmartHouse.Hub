using Microsoft.AspNetCore.Mvc;
using SmartHouseHub.API.Interfaces;
using ZWaveLib;

namespace SmartHouseHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ZWaveController : Controller
	{
		private readonly IZWaveBrokerService _zWaveBrokerService;
		public ZWaveController(IZWaveBrokerService zWaveBrokerService)
        {
            _zWaveBrokerService = zWaveBrokerService;
        }

		[HttpGet("id")]
		public async Task<ZWaveNode> GetNodeById(byte id)
		{
			try
			{
				return await _zWaveBrokerService.GetNodeById(id);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet("")]
		public async Task<List<ZWaveNode>> GetAllNode()
		{
			try
			{
				return await _zWaveBrokerService.GetAllNode();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet("/Swith{state}")]
		public async Task SendBinerySwith(bool state)
		{
			try
			{
				await _zWaveBrokerService.SendBinerySwith(state);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet("/Initialize")]
		public async Task Initialize()
		{
			try
			{
				await _zWaveBrokerService.Initialize();
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
