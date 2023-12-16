using SmartHouseHub.API.Interfaces;
using ZWaveLib;

namespace SmartHouseHub.API.Servises
{
	public class ZWaveBrokerService : IZWaveBrokerService
	{
		private readonly IZWaveBroker _broker;

		public ZWaveBrokerService(IZWaveBroker broker)
		{
			_broker = broker;
		}

		public async Task<List<ZWaveNode>> GetAllNode()
		{
			return _broker.GetAllNode();
		}

		public async Task<ZWaveNode> GetNodeById(byte nodeId)
		{
			return _broker.GetNodeById(nodeId);
		}

		public async Task SendBinerySwith(bool state)
		{
			var allNodes = _broker.GetAllNode();

			foreach (var node in allNodes)
			{
				_broker.SendBinarySwitchCommand(node.Id, state);
			}
		}

		public async Task Initialize()
		{
			_broker.Initialize();
		}

		public async Task Stop()
		{
			_broker.Dispose();
		}
	}
}
