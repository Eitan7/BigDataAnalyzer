using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BigDataAnalyzer
{
    class Mongo
    {
        private string connectionString;
        MongoClient client;
        IMongoCollection<BsonDocument> collection;
        public Mongo(string servername = "localhost", int portNumber = 27017)
        {
             connectionString = "mongodb://" + servername + ":" + portNumber.ToString();
             client = new MongoClient(connectionString);

            //MongoServer server = client.GetServer();
            var database = client.GetDatabase("foo");
            collection = database.GetCollection<BsonDocument>("foo");
        }

        public async Task Find()
        {
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                   var batch = cursor.Current;
                   foreach (var document in batch)
                    {
                        // process document
                       count++;
                    }
                }
            }

        }


    }
}
