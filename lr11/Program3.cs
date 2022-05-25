using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr11
{
    class Repositories
    {
        public Object Id { get; set; }
        public string title { get; set; }
        public string DateAdd { get; set; }
        public List<string> language { get; set; }
        public User RepOwner { get; set; }
    }
    class User
    {
        public string Name { get; set; }
    }
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
            var collection = database.GetCollection<Repositories>("repositories");

            Repositories rep = new Repositories
            {
                title = "test",
                language = new List<string> { "C++ ", "C# "},
                DateAdd = DateTime.Now.ToString("MM/dd/yyyy"),

                RepOwner = new User
                {
                    Name = "Ivan"
                }
            };
            await collection.InsertOneAsync(rep);
            Console.Write(rep.Id);
            //Console.Write(rep.Title + " ");
            //for (int i = 0; i < rep.Language.Count; i++)
            //{
            //    Console.Write(rep.Language[i]);
            //}
            //Console.Write(rep.DateAdd + " ");
            //Console.Write(rep.RepOwner + " ");
        }

    }
}
