using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr10
{
    class User
    {
        [BsonId]
        public string _id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [BsonIgnoreIfNull]
        public object repositories { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var conventionPack = new ConventionPack();
            conventionPack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register(name: "camelCase", conventionPack, filter: _ => true);
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(p => p.Name).SetElementName("name");
                cm.MapMember(p => p.Surname).SetElementName("surname");
                cm.MapMember(p => p.Password).SetElementName("password");
                cm.MapMember(p => p.Email).SetElementName("email");
            });
            var user = new User
            {
                Name = "Ivan", Surname = "Shpytchuk",
                Password = "qwerty", Email = "ivan@gmail.com"
            };
            Console.WriteLine(user.ToBsonDocument());
            Console.ReadKey();
        }
    }
}
