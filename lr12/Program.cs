using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr12
{
    class Program
    {
        static void Main(string[] args)
        {
            FindDocs().GetAwaiter().GetResult();
            Console.ReadLine();

        }
        private static async Task FindDocs()
        {
            string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("github");
            var collection = database.GetCollection<BsonDocument>("users");
            var filter = new BsonDocument();
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var users = cursor.Current;
                    foreach (var doc in users)
                    {
                        Console.WriteLine(doc);
                    }
                }

            }

        }
    }
}
