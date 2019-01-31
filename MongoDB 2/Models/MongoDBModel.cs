using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDB_2.Models
{
    public class MongoDBModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Oyuncu")]
        public string Oyuncu { get; set; }
        [BsonElement("Mevki")]
        public string Mevki { get; set; }
        [BsonElement("Bonservis")]
        public decimal Bonservis { get; set; }
        [BsonElement("Kulup")]
        public string Kulup { get; set; }
        [BsonElement("Numara")]
        public byte Numara { get; set; }
    }
}