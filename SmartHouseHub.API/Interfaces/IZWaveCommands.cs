using ZWaveLib;

namespace SmartHouseHub.API.Interfaces
{
	public interface IZWaveCommands
	{
		void SendBinarySwitchCommand(ZWaveNode node, bool state);
	}
}
