﻿using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace MongoDemo
{
    public static class DeposeMethodique
    {
        public static void FlashDepose(string id)
        {
            IMongoCollection<ToDoItem> collection = MongoService.GetItemsCollection;
            var entity = collection.Find(document => document.Id == id).FirstOrDefault();
            //return entity.ToString();
        }
    }
}