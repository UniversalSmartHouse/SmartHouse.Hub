using LiteDB;
using Medallion.Shell;
using SmartHouseHub.API.DTOs;

namespace SmartHouseHub.API.Helpers
{
    public class LiteDbHelper : IDisposable
    {
        public LiteDatabase Database { get; private set; }
        public ILiteCollection<DeviceDto> Instances { get; private set; }
        public ILiteCollection<LogDto> Log { get; private set; }

        public LiteDbHelper()
        {
            try
            {
                CreateDbInstance();
            }
            catch
            {
                if (Database != null)
                {
                    Database.Dispose();
                }

                var result = Command.Run("/bin/bash/", "shall/closeProcces.sh").Result;

                if (result.Success)
                {
                    CreateDbInstance();
                }
            }
        }

        public void Dispose()
        {
            if (Database != null)
            {
                Database.Dispose();
            }
        }

        private void CreateDbInstance()
        {
            Database = new(
               Path.Combine(Directory.GetCurrentDirectory(),
               Environment.GetEnvironmentVariable("DATABASE_FILE")));

            Instances = Database.GetCollection<DeviceDto>("Instances");
            Log = Database.GetCollection<LogDto>("Log");
        }
    }
}
