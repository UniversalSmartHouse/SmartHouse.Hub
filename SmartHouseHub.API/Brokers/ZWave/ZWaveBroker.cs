﻿using SmartHouseHub.API.Interfaces;
using ZWaveLib;

namespace SmartHouseHub.API.Brokers.ZWave
{
	public class ZWaveBroker : IZWaveBroker
	{
		private readonly ZWaveController _controller;

		public ZWaveBroker(string serialPort)
		{
			_controller = new ZWaveController(serialPort);

			_controller.ControllerStatusChanged += StatusChangedHandler;
			_controller.NodeOperationProgress += NodeOperationProgressHandler;
			_controller.NodeUpdated += NodeUpdatedHandler;
			_controller.DiscoveryProgress += DiscoveryProgress;
		}

		public void Initialize()
		{
			_controller.Connect();
		}

		public void AddDevice(byte nodeId)
		{
			var existingNode = _controller.Nodes.Where(x => x.Id == nodeId);

			if (existingNode == null)
			{
				_controller.Nodes.Add(new ZWaveNode() { Id = nodeId });
			}
		}

		public void RemoveDevice(byte nodeId)
		{
			var existingNode = _controller.Nodes.FirstOrDefault(x => x.Id == nodeId);

			if (existingNode != null)
			{
				_controller.Nodes.Remove(existingNode);
			}
		}
		
		//TODO need to move it
		public void SendBinarySwitchCommand(byte nodeId, bool state)
		{
			var node = _controller.GetNode(nodeId);

			if (node.SupportCommandClass(CommandClass.SwitchBinary))
			{
				_controller.SendMessage(new ZWaveMessage(ZWaveCommands.SwitchBinary(state, node.Id)));
			}
		}

		public void Dispose()
		{
			_controller.Dispose();
		}

		private void NodeUpdatedHandler(object sender, NodeUpdatedEventArgs args)
		{
			if (args != null) 
			{
				var existingNode = _controller.Nodes.Where(x => x.Id == args.NodeId);

				if (existingNode == null) 
				{
					_controller.Nodes.Add(new ZWaveNode() { Id = args.NodeId });
				}
			}
		}

		private void NodeOperationProgressHandler(object sender, NodeOperationProgressEventArgs args)
		{
			switch (args.Status)
			{
				case NodeQueryStatus.NodeAdded:
					break;
				case NodeQueryStatus.NodeRemoved:
					break;
				case NodeQueryStatus.NodeUpdated:
					break;
				case NodeQueryStatus.NodeAddReady:
					break;
				case NodeQueryStatus.NodeAddStarted:
					break;
				case NodeQueryStatus.NodeAddDone:
					break;
				case NodeQueryStatus.NodeAddFailed:
					break;
				case NodeQueryStatus.NodeRemoveReady:
					break;
				case NodeQueryStatus.NodeRemoveStarted:
					break;
				case NodeQueryStatus.NodeRemoveDone:
					break;
				case NodeQueryStatus.NodeRemoveFailed:
					break;
				case NodeQueryStatus.NeighborUpdateStarted:
					break;
				case NodeQueryStatus.NeighborUpdateDone:
					break;
				case NodeQueryStatus.NeighborUpdateFailed:
					break;
				case NodeQueryStatus.Error:
					break;
				case NodeQueryStatus.Timeout:
					break;
				default:
					break;
			}
		}

		private void StatusChangedHandler(object sender, ControllerStatusEventArgs args)
		{
			switch (args.Status)
			{
				case ControllerStatus.Connected:
					_controller.Initialize();
					break;
				case ControllerStatus.Disconnected:
					break;
				case ControllerStatus.Initializing:
					break;
				case ControllerStatus.Ready:
					_controller.Discovery();
					break;
				case ControllerStatus.Error:
					break;
				default:
					break;
			}
		}

		private void DiscoveryProgress(object sender, DiscoveryProgressEventArgs args)
		{
			switch (args.Status)
			{
				case DiscoveryStatus.DiscoveryStart:
					break;
				case DiscoveryStatus.DiscoveryEnd:
					break;
			}
		}
	}
}