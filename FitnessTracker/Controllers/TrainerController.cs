using FitnessTracker.Models;
using FitnessTracker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            var trainers = TrainerRepository.GetAllTrainers();
            return View(trainers);
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int id)
        {
            var trainer = TrainerRepository.GetTrainerById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View(new Trainer());
        }

        // POST: Trainer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                TrainerRepository.AddTrainer(trainer);
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            var trainer = TrainerRepository.GetTrainerById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                TrainerRepository.UpdateTrainer(trainer);
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            var trainer = TrainerRepository.GetTrainerById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerRepository.DeleteTrainer(id);
            return RedirectToAction("Index");
        }
    }

}
