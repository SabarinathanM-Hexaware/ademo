using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace demoapp.Contracts.DTO {
   public class ProdDto { 
     public string Id { get; set; }
        public string name { get; set; } 
} 
}
