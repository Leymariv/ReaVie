using System.Linq;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace MongoDemo
{
    public static class Diagnostics
    {
        public async static void CreateItem(    string type
                                            ,   string subType
                                            ,   string volumeOrQuantity
                                            ,   string instructions
                                            ,   string state
                                            ,   string chantierId)
        {
            var statesArray = new BsonArray();
            statesArray.Add(new BsonDocument("Diagnostic", state));

            DateTime today = DateTime.Today;
            var datesArray = new BsonArray();
            datesArray.Add(new BsonDocument("Diagnostic", today.ToString("dd/MM/yyyy")));

            var newItem = new ToDoItem { Type = type, SubType = subType, Volume = volumeOrQuantity, Etat = statesArray, ChantierId = chantierId, Instructions = instructions, Dates = datesArray };
            await MongoService.InsertItem(newItem);
        }
    }
}
