using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDemo.App_Start;
using MongoDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDemo.Controllers
{
    public class CarinformationController : Controller
    {
        MongoContext _dbContext;

        public CarinformationController()
        {
            _dbContext = new MongoContext();
        }
        // GET: Carinformation
        public ActionResult Index()
        {
            var carDetails = _dbContext._database.GetCollection<CarModel>("CarModel").FindAll().ToList();

            return View(carDetails);
        }

        // GET: Carinformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carinformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carinformation/Create
        [HttpPost]
        public ActionResult Create(CarModel carmodel)
        {
            var document = _dbContext._database.GetCollection<BsonDocument>("CarModel");

            var query = Query.And(Query.EQ("Carname", carmodel.Carname), Query.EQ("Color", carmodel.Color));

            var count = document.FindAs<CarModel>(query).Count();

            if (count == 0)
            {
                var result = document.Insert(carmodel);
            }
            else
            {
                TempData["Message"] = "Carname Already Exist";
                return View("Create", carmodel);
            }
            return RedirectToAction("Index");
        }

        // GET: Carinformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carinformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carinformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carinformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
