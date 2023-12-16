using ZWaveLib;

namespace SmartHouseHub.API.Interfaces
{
	public interface IZWaveBroker : IDisposable
	{
		void Initialize();
		void AddDevice(byte nodeId);
		void RemoveDevice(byte nodeId);
		void SendBinarySwitchCommand(byte nodeId, bool state);
		List<ZWaveNode> GetAllNode();
		ZWaveNode GetNodeById(byte nodeId);
	}
}
