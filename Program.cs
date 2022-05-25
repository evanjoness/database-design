using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr9
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("github");
            var col = db.GetCollection<User>("users");
            var users = col
                .Find(_ => true)
                .ToListAsync()
                .Result;

            Console.WriteLine("User is: " + users[0].name + users[0].surname);

            BsonDocument doc = new BsonDocument
        {
            {"name","Bill"},
            {"surname", "Gates"},
            {"password", "13333333"},
            { "email", "microsoft@.ua"}
        };

            User p = BsonSerializer.Deserialize<User>(doc);
            Console.WriteLine(p.ToJson());

            User u = new User
            {
                name = "Bill",
                surname = "Gates",
                email = "newEmail",
                password = "dsaasdrgfd",
                _id = ObjectId.GenerateNewId()
            };
            Console.WriteLine(u.ToBsonDocument());


            col.InsertOne(u);
            Console.ReadKey();
        }
    }
}
