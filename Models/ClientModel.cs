using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace EAD_Ticket_Reservation_system.Models
{
    [BsonIgnoreExtraElements]
    public class ClientModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("date")]
        public string? Date { get ; set; }
    }
}
