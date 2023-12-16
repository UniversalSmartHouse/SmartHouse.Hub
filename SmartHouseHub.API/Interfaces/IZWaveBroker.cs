using ZWaveLib;

namespace SmartHouseHub.API.Interfaces
{
	public interface IZWaveBroker : IDisposable
	{
		void AddDevice(byte nodeId);
		void RemoveDevice(byte nodeId);
		List<ZWaveNode> GetAllNode();
		ZWaveNode GetNodeById(byte nodeId);
	}
}
