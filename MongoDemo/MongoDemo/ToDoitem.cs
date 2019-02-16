using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDemo
{
    public class ToDoItem
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Volume")]
        public string Volume { get; set; }

        [BsonElement("Etat")]
        public BsonArray Etat { get; set; }

        [BsonElement("Instructions")]
        public string Instructions { get; set; }

        [BsonElement("ChantierId")]
        public string ChantierId { get; set; }

        [BsonElement("SubType")]
        public string SubType { get; set; }

        [BsonElement("Etat")]
        public BsonArray Dates { get; set; }
    }
}
