namespace FitnessTracker.Models
{
    public enum SubscriptionType
    {
        Monthly,
        Quarterly,
        HalfYearly,
        Yearly
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public long PhoneNumber { get; set; }
        public SubscriptionType SubscriptionType { get; set; } = SubscriptionType.Monthly; // Default value
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);

        public int? TrainerId { get; set; }
        public Trainer? AssignedTrainer { get; set; }
    }
}
