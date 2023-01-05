using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ERns.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Prod
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string name  { get; set; }
        
    }

}
