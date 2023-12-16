using SmartHouseHub.API.Interfaces;
using ZWaveLib;

namespace SmartHouseHub.API.Brokers.ZWave
{
	public class ZWaveCommands : IZWaveCommands
	{
		public void SendBinarySwitchCommand(ZWaveNode node, bool state)
		{
			if (node.SupportCommandClass(CommandClass.SwitchBinary))
			{
				node.SendDataRequest(ZWaveUtilsCommands.SwitchBinary(state));
			}
		}
	}
}
