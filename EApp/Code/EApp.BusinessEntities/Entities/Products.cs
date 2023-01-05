using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EApp.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string name  { get; set; }
        
    }

}
