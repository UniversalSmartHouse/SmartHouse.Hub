using ZWaveLib;

namespace SmartHouseHub.API.Interfaces
{
	public interface IZWaveBrokerService
	{
		Task SendBinerySwith(bool state);
		Task Stop();
		Task<List<ZWaveNode>> GetAllNode();
		Task<ZWaveNode> GetNodeById(byte nodeId);
	}
}
