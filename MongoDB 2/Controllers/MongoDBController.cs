using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_2.App_Start;
using MongoDB_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDB_2.Controllers
{
    public class MongoDBController : Controller
    {
        private MongoDBContext dbContext;
        private IMongoCollection<MongoDBModel> pc;
        public MongoDBController()
        {
            dbContext = new MongoDBContext();
            pc = dbContext.database.GetCollection<MongoDBModel>("Logs");
        } 

        // GET: Mongo
        public ActionResult Index()
        {
            List<MongoDBModel> logs = pc.AsQueryable().ToList();
            return View(logs);
        }

        // GET: Mongo/Details/5
        public ActionResult Details(string id)
        {
            var logID = new ObjectId(id);
            var log = pc.AsQueryable().SingleOrDefault(x => x.Id == logID);
            return View(log);
        }

        // GET: Mongo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mongo/Create
        [HttpPost]
        public ActionResult Create(MongoDBModel collection)
        {
            try
            {
                pc.InsertOne(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mongo/Edit/5
        public ActionResult Edit(string id)
        {
            var logID = new ObjectId(id);
            var log = pc.AsQueryable().SingleOrDefault(x => x.Id == logID);
            return View(log);
        }

        // POST: Mongo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MongoDBModel collection)
        {
            try
            {
                var filter = Builders<MongoDBModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<MongoDBModel>.Update
                    .Set("Oyuncu", collection.Oyuncu)
                    .Set("Mevki", collection.Mevki)
                    .Set("Bonservis", collection.Bonservis)
                    .Set("Kulup", collection.Kulup)
                    .Set("Numara", collection.Numara);
                var result = pc.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mongo/Delete/5
        public ActionResult Delete(string id)
        {
            var logID = new ObjectId(id);
            var log = pc.AsQueryable().SingleOrDefault(x => x.Id == logID);
            return View(log);
        }

        // POST: Mongo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                pc.DeleteOne(Builders<MongoDBModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public int toplam = 0;
    }
}
