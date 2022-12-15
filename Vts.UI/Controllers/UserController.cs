using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vts.Dal;
using Vts.Entites;
using System.Web.Helpers;

namespace Vts.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User


        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository repository)
        {
            _userRepository = repository;

        }
        public ActionResult Index()
        {

            return View(_userRepository.GetUsers());

        }
        public ActionResult Details(int id)
        {

            var userDetails = _userRepository.GetUsers(id);
            return View(userDetails);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User @user)
        {
            if (ModelState.IsValid)
            {

                int result = _userRepository.InsertUser(@user);
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

            return View(_userRepository.GetUsers(id));
        }
        [HttpPost]
        public ActionResult Update(User @user)
        {
            if (ModelState.IsValid)
            {


                int result = _userRepository.UpdateUser(@user);
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

                int result = _userRepository.DeleteUser(id);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}