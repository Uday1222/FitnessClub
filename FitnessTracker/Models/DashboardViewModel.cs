using System.Diagnostics;

namespace FitnessTracker.Models
{
    public class DashboardViewModel
    {
        //public List<User> Users { get; set; }
        //public List<UserActivity> Activities { get; set; }
        //public Dictionary<string, int> WorkoutTypeCounts { get; set; }
        //public List<int> NewUsersPerMonth { get; set; }

        //// Additional statistics
        //public string MostPopularWorkout { get; set; }
        //public int TotalWorkoutHours { get; set; }
        //public List<string> TopActiveUsers { get; set; }
        //public int DailyGoalAchievementPercentage { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<UserActivity> Activities { get; set; }
        public Dictionary<string, int> WorkoutTypeCounts { get; set; }
        public Dictionary<int, int> NewUsersPerMonth { get; set; }
        public string MostPopularWorkout { get; set; }
        public double TotalWorkoutHours { get; set; }
        public List<string> TopActiveUsers { get; set; }
        public double DailyGoalAchievementPercentage { get; set; }
    }

}
