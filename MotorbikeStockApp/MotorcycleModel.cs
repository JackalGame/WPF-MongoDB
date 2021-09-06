using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MotorbikeStockApp
{
    public class MotorcycleModel
    {
        [BsonId] 
        public Guid Id { get; set; }
        public string VehicleRegistration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Millage { get; set; }
        public DateTime DatePurchased { get; set; }

        public PersonModel PreviousOwner { get; set; }
    }
}
