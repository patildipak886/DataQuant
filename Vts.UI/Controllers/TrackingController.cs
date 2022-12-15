using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vts.Dal;
using Vts.Entites;
namespace Vts.UI.Controllers
{
    public class TrackingController : Controller
    {
        private readonly ITrackingRepository trackingRepository;
        public TrackingController(ITrackingRepository repository)
        {
            trackingRepository = repository;

        }
        public ActionResult Index()
        {

            return View(trackingRepository.GetTrackings());

        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            var userDetails = trackingRepository.GetTracking(id);
            return View(userDetails);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tracking @tracking)
        {
            if (ModelState.IsValid)
            {

                int result = trackingRepository.InserTracking(tracking);
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

            return View(trackingRepository.GetTracking(id));
        }
        [HttpPost]
        public ActionResult Update(Tracking tracking)
        {
            if (ModelState.IsValid)
            {


                int result = trackingRepository.UpdateTracking(tracking);
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

                int result = trackingRepository.DeleteTracking(id);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }


}