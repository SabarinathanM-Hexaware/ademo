using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace EApp.Contracts.DTO {
   public class ProductsDto { 
     public string Id { get; set; }
        public string name { get; set; } 
} 
}
