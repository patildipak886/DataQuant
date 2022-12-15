using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vts.Dal;
using Vts.Entites;

namespace Vts.UI.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;
        public VehicleController(IVehicleRepository repository)
        {
            vehicleRepository = repository;

        }
        public ActionResult Index()
        {

            return View(vehicleRepository.GetVehicles());

        }

        public ActionResult Details(int id)
        {

            var vehicleDetails = vehicleRepository.GetVehicles(id);
            return View(vehicleDetails);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vehicle @vehicle)
        {
            if (ModelState.IsValid)
            {

                int result = vehicleRepository.InsertVehicle(vehicle);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {

            return View(vehicleRepository.GetVehicles(id));
        }
        [HttpPost]
        public ActionResult Update(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {


                int result = vehicleRepository.UpdateVehicle(vehicle);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                int result = vehicleRepository.DeleteVehicle(id);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}