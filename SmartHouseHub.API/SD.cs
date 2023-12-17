namespace SmartHouseHub.API
{
    public static class SD
    {
        //public static string GetSyncGatewayHost => Environment.GetEnvironmentVariable("GET_SYNC_GATEWAY_HOST");
        public static string LiteDBFile => Environment.GetEnvironmentVariable("DATABASE_FILE");
        //TODO: Need to delete it
        public static string GetSyncGatewayHost => "localhost:4984";
    }
}
