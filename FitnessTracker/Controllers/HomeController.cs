using FitnessTracker.Models;
using FitnessTracker.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ActivityService _activityService;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _activityService = new ActivityService();
            _userService = new UserService();
        }

        public IActionResult Index()
        {

            //var model = new DashboardViewModel
            //{
            //    Users = UserRepository.users,//_userService.GetUsers(),
            //    Activities = StaticUserActivityRepository.Activities,//_activityService.GetActivities(),
            //    WorkoutTypeCounts = wktTypes,//_activityService.GetWorkoutTypeCounts(),
            //    NewUsersPerMonth = new List<int> { 1, 4},//_userService.GetNewUsersPerMonth(),
            //    MostPopularWorkout = "Chest",//_activityService.GetMostPopularWorkoutType(),
            //    TotalWorkoutHours = 100,//_activityService.GetTotalWorkoutHours(),
            //    TopActiveUsers = new List<string> { "Uday"}, //_activityService.GetTopActiveUsers(),
            //    DailyGoalAchievementPercentage = 70,//_activityService.GetDailyGoalAchievementPercentage()
            //};

            var model = new DashboardViewModel
            {
                Users = _userService.GetUsers().ToList(),
                Activities = _activityService.GetActivities(),
                WorkoutTypeCounts = _activityService.GetWorkoutTypeCounts(),
                NewUsersPerMonth = _userService.GetNewUsersPerMonth(),
                MostPopularWorkout = _activityService.GetMostPopularWorkoutType(),
                TotalWorkoutHours = _activityService.GetTotalWorkoutHours(),
                TopActiveUsers = _activityService.GetTopActiveUsers(),
                DailyGoalAchievementPercentage = _activityService.GetDailyGoalAchievementPercentage()
            };

            return View(model);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
