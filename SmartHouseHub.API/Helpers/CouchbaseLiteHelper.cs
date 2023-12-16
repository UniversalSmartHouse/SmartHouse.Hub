using Couchbase.Lite;
using Couchbase.Lite.Sync;
using SmartHouseHub.API.DTOs;

namespace SmartHouseHub.API.Helpers
{
    public class CouchbaseLiteHelper
    {
        public CouchbaseLiteHelper()
        {
            
        }

        public void CreateReplicator(UserDto user)
        {
            var database = new Database(user.DbName);
            var collection = database.GetDefaultCollection();

            var replConfig = new ReplicatorConfiguration(new URLEndpoint(new($"ws://{SD.GetSyncGatewayHost}/{user.DbName}")));
            replConfig.Authenticator = new BasicAuthenticator(user.Username, user.Password);
            replConfig.AddCollection(collection);

            var replicator = new Replicator(replConfig);

            replicator.AddChangeListener((sender, args) =>
            {
                if (args.Status.Error != null)
                {
                    Console.WriteLine($"Error :: {args.Status.Error}");
                }
            });

            replicator.Start();
        }
    }
}
