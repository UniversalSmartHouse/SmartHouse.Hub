﻿namespace SmartHouseHub.API.DTOs
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string DbName { get; set; }
    }
}
