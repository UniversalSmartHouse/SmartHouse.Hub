using SmartHouseHub.API.Interfaces;
using ZWaveLib;

namespace SmartHouseHub.API.Servises
{
	public class ZWaveBrokerService : IZWaveBrokerService
	{
		private readonly IZWaveBroker _broker;
		private readonly IZWaveCommands _commands;

		public ZWaveBrokerService(IZWaveBroker broker, IZWaveCommands commands)
		{
			_broker = broker;
			_commands = commands;
		}

		public async Task<List<ZWaveNode>> GetAllNode()
		{
			return _broker.GetAllNode();
		}

		public async Task<ZWaveNode> GetNodeById(byte nodeId)
		{
			return _broker.GetNodeById(nodeId);
		}

		public async Task RemoveDevice(byte id)
		{
			_broker.RemoveDevice(id);
		}

		public async Task SendBinerySwith(bool state)
		{
			var allNodes = _broker.GetAllNode();

			foreach (var node in allNodes)
			{
				_commands.SendBinarySwitchCommand(node, state);
			}
		}

		public async Task Stop()
		{
			_broker.Dispose();
		}
	}
}
