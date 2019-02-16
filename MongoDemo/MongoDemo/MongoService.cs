using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace MongoDemo
{
    public static class MongoService
    {

        static IMongoCollection<ToDoItem> todoItemsCollection;
        static IMongoCollection<Chantier> chantierCollection;
        readonly static string dbName = "BlogDemo";
        readonly static string collectionName = "ToDoItems";
        readonly static string chantierCollectionName = "chantierList";
        readonly static string userName = "reavie-project";
        readonly static string host = "reavie-project.documents.azure.com";
        readonly static string password = "hXej44XKDgXN52Eb7ROZropb5LHTTMiY30iwMfDXV9wmVAeyLOhXXJRRKWaJlLjmX1TpnDXflQZLShhz0q3RQw==";
        static MongoClient client;
        public static IMongoDatabase MyDb;

        static void InitDatabase()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, 10255);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            client = new MongoClient(settings);
            MyDb = client.GetDatabase(dbName);
        }

        public static IMongoCollection<ToDoItem> GetItemsCollection
        {
            get
            {
                if (MyDb == null)
                    InitDatabase();

                if (todoItemsCollection == null)
                    todoItemsCollection = MyDb.GetCollection<ToDoItem>(collectionName);

                return todoItemsCollection;
            }
        }

        static IMongoCollection<Chantier> GetChantierCollection
        {
            get
            {
                if (MyDb == null)
                    InitDatabase();

                if (chantierCollection == null)
                    chantierCollection = MyDb.GetCollection<Chantier>(chantierCollectionName);

                return chantierCollection;
            }
        }

        public async static Task<List<Chantier>> GetAllChantiers()
        {
            var allItems = await GetChantierCollection
                .Find(new BsonDocument())
                .ToListAsync();

            return allItems;
        }

        public async static Task<List<ToDoItem>> GetAllItems()
        {
            var allItems = await GetItemsCollection
                .Find(new BsonDocument())
                .ToListAsync();

            return allItems;
        }

        public async static Task<List<ToDoItem>> SearchByName(string name)
        {
            var results = await GetItemsCollection
                            .AsQueryable()
                            .Where(tdi => tdi.Type.Contains(name))
                            .Take(10)
                            .ToListAsync();

            return results;
        }

        public async static Task InsertChantier(Chantier item)
        {
            await GetChantierCollection.InsertOneAsync(item);
        }

        public async static Task<bool> DeleteChantier(Chantier item)
        {
            var result = await GetChantierCollection.DeleteOneAsync(tdi => tdi.Id == item.Id);
            return result.IsAcknowledged && result.DeletedCount == 1;
        }

        public async static Task InsertItem(ToDoItem item)
        {
            await GetItemsCollection.InsertOneAsync(item);
        }

        public async static Task<bool> DeleteItem(ToDoItem item)
        {
            var result = await GetItemsCollection.DeleteOneAsync(tdi => tdi.Id == item.Id);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
