using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDemo
{
    public class ToDoItem
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Type")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("Volume")]
        public string Volume { get; set; }

        [BsonElement("Etat")]
        public string Etat { get; set; }

        [BsonElement("Instructions")]
        public string Instructions { get; set; }
    }
}
