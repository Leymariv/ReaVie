using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace MongoDemo
{
    public static class DeposeMethodique
    {
        public static void FlashDepose(string qrcode)
        {
            IMongoCollection<ToDoItem> collection = MongoService.GetItemsCollection;
            var entity = collection.Find(document => document.QRCode == qrcode).FirstOrDefault();
            //return entity.ToString();
        }

        public static void ModifyState(string qrcode, string newState)
        {
            IMongoCollection<ToDoItem> collection = MongoService.GetItemsCollection;
            var entity = collection.Find(document => document.QRCode == qrcode).FirstOrDefault();
            //return entity.ToString();
        }
    }
}