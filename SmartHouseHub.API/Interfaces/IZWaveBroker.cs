namespace SmartHouseHub.API.Interfaces
{
	public interface IZWaveBroker : IDisposable
	{
		void Initialize();
		void AddDevice(byte nodeId);
		void RemoveDevice(byte nodeId);
	}
}
