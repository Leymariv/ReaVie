using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDemo
{
    public class Chantier
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Location")]
        public string Location { get; set; }

        [BsonElement("ReferenceChantier")]
        public string ReferenceChantier { get; set; }

        [BsonElement("Owner")]
        public string Owner { get; set; }

        [BsonElement("BeginDate")]
        public string BeginDate { get; set; }
    }
}