using LiteDB;
using Medallion.Shell;

namespace SmartHouseHub.API.Helpers
{
    public class LiteDbHelper : IDisposable
    {
        public readonly LiteDatabase db;

        public LiteDbHelper()
        {
            try
            {
                db = CreateDbInstance();
            }
            catch
            {
                if (db != null)
                {
                    db.Dispose();
                }

                var result = Command.Run("/bin/bash/", "shall/closeProcces.sh").Result;

                if (result.Success)
                {
                    db = CreateDbInstance();
                }
            }
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        private LiteDatabase CreateDbInstance()
        {
            return new(Path.Combine(Directory.GetCurrentDirectory(), Environment.GetEnvironmentVariable("DATABASE_FILE")));
        }
    }
}
