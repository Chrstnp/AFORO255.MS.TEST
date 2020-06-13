using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AFORO255.MS.TEST.Transaction.Model
{
    public class PayTransaction
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int id_transaccion { get; set; }
        public int id_invoice { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
    }
}
