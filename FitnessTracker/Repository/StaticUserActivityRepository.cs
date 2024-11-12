using FitnessTracker.Models;
using System.Diagnostics;

namespace FitnessTracker.Repository
{
    public static class StaticUserActivityRepository
    {
        public static List<UserActivity> Activities { get; set; } = new List<UserActivity>();

        public static IEnumerable<UserActivity> GetActivities() => Activities;

    }
    public class ActivityService
    {
        public IEnumerable<UserActivity> GetActivities()
        {
            return StaticUserActivityRepository.GetActivities();
        }

        public Dictionary<string, int> GetWorkoutTypeCounts()
        {
            return StaticUserActivityRepository.GetActivities()
                .GroupBy(a => a.WorkoutType)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public string GetMostPopularWorkoutType()
        {
            return StaticUserActivityRepository.GetActivities()
                .GroupBy(a => a.WorkoutType)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        public double GetTotalWorkoutHours()
        {
            return StaticUserActivityRepository.GetActivities().Sum(a => a.Duration);
        }

        public List<string> GetTopActiveUsers()
        {
            return StaticUserActivityRepository.GetActivities()
                .GroupBy(a => a.UserId)
                .OrderByDescending(g => g.Sum(a => a.Duration))
                .Take(3) // Get top 3 active users
                .Select(g => UserRepository.users.FirstOrDefault(u => u.UserId == g.Key)?.Name)
                .Where(name => name != null)
                .ToList();
        }

        public double GetDailyGoalAchievementPercentage()
        {
            double dailyGoal = UserRepository.users.Count > 0 ? UserRepository.users.Count : 1; // Example goal in hours
            double totalWorkoutHoursToday = StaticUserActivityRepository.GetActivities()
                .Where(a => a.ActivityDate.Date == DateTime.Today)
                .Sum(a => a.Duration);

            return ((totalWorkoutHoursToday/60) / dailyGoal) * 100;
        }
    }


}
