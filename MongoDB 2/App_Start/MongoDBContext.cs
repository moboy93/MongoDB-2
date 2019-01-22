using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MongoDB_2.App_Start
{
    public class MongoDBContext
    {
        public IMongoDatabase database;
        public MongoDBContext()
        {
            var MongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            database = MongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }
    }
}