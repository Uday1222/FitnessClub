using FitnessTracker.Models;
using FitnessTracker.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessTracker.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var users = UserRepository.GetAllUsers();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = UserRepository.GetUserById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.Trainers = new SelectList(TrainerRepository.GetAllTrainers(), "TrainerId", "Name");
            return View(new User());
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.AddUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = UserRepository.GetUserById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = UserRepository.GetUserById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
