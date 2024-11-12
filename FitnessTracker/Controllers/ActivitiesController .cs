using FitnessTracker.Models;
using FitnessTracker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class ActivitiesController : Controller
    {
        private static List<User> _users = UserRepository.users;
        private static List<UserActivity> _activities = StaticUserActivityRepository.Activities;

        // GET: Activities/Log
        public IActionResult Log()
        {
            ViewBag.WorkoutTypes = new List<string> { "Chest", "Arms", "Back", "Core", "Shoulders", "Legs", "Cardio" };
            return View(new UserActivity { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Log(UserActivity activity)
        {
            //if (ModelState.IsValid)
            {
                // Find the user to get their name
                var user = _users.FirstOrDefault(u => u.UserId == activity.UserId);
                if (user != null)
                {
                    activity.UserName = user.Name;
                    activity.ActivityId = _activities.Count + 1;
                    _activities.Add(activity);
                }
                else
                {
                    ModelState.AddModelError("UserId", "User not found.");
                    RedirectToAction("Log");
                }

                return RedirectToAction(nameof(Index));
            }

            //ViewBag.WorkoutTypes = new List<string> { "Chest", "Arms", "Back", "Core", "Shoulders", "Legs", "Cardio" };
            //return View(activity);
        }

        // GET: Activities/Index
        public IActionResult Index(string searchTerm)
        {
            var activities = _activities.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                activities = activities.Where(a => a.UserName.ToLower().Contains(searchTerm.ToLower()));
            }

            return View(activities.ToList());
        }
    }
}
