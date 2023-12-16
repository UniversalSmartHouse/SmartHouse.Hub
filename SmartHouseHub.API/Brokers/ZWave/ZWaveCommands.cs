namespace SmartHouseHub.API.Brokers.ZWave
{
	public static class ZWaveCommands
	{
		private readonly static byte _commandClass = 0x25;
		private readonly static byte _commandTypeSet = 0x01;

		public static byte[] SwitchBinary(bool state) =>
			new byte[] { _commandClass, _commandTypeSet, state ? (byte)0xFF : (byte)0x00 };
	}
}
