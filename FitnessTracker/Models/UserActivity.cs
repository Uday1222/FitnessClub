using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class UserActivity
    {
        public int ActivityId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public DateTime ActivityDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Workout Type")]
        public string WorkoutType { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Duration should be between 1 and 500 minutes.")]
        public int Duration { get; set; } // Duration in minutes
    }
}
