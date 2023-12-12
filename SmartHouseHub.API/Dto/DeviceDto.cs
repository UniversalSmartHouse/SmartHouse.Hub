namespace SmartHouseHub.API.Dto
{
	public class DeviceDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public InstanceStatus InstanceStatus { get; set; }
		public AlarmStatus AlarmStatus { get; set; }
		public DateTime LaunchTime { get; set; }
		public string? IPv4 { get; set; }
		public string? IPv6 { get; set; }
	}
}
