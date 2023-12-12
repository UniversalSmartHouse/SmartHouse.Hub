namespace SmartHouseHub.API.DTOs
{
	public class LogDto
	{
		public Guid Id { get; set; }
		public string Message { get; set; }
		public LogType Type { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
