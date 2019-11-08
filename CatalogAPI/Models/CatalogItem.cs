using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Models
{
    public class CatalogItem
    {
        public CatalogItem()
        {
            Vendors = new List<Vendor>();
        }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Price")]
        public double Price { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
        [BsonElement("ReorderLevel")]
        public int ReorderLevel { get; set; }
        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("ManufacturingDate")]
        public DateTime ManufacturingDate { get; set; }
        public List<Vendor> Vendors { get; set; }

    }
    public class Vendor
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("ContactNo")]
        public string ContactNo { get; set; }
        [BsonElement("Address")]
        public string Address { get; set; }

    }
}
