using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr11
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveDocs().GetAwaiter().GetResult();
            Console.ReadLine();
        }
        private static async Task SaveDocs()
        {
            string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("github");
            var collection = database.GetCollection<BsonDocument>("users");
            BsonDocument person1 = new BsonDocument
            {
                {"name", "Alex"},
                {"surname", "Zinchenko"},
                {"password", "qqqq"},
                {"email", "Alex@gmail.com"},

            };
            await collection.InsertOneAsync(person1);

        }
    }
}
