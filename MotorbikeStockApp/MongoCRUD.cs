using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MotorbikeStockApp
{
    public class MongoCRUD
    {
        public IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public bool CheckForExistingRecord<T>(string table, string vehicleReg)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("VehicleRegistration", vehicleReg);

            if(collection.Find(filter).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<T> LoadDistinctList<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public List<T> LoadFilteredList<T>(string table, string filterItem)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Manufacturer", filterItem);

            return collection.Find((filter)).ToList();
        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }

        public void UpsertRecord<T>(string table, string vehicleReg, T record)
        {
            var collection = db.GetCollection<T>(table);

            var result = collection.ReplaceOne(
                new BsonDocument("VehicleRegistration", vehicleReg),
                record,
                new ReplaceOptions { IsUpsert = true });
        }

        public T FindRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).FirstOrDefault();
        }
    }
}
