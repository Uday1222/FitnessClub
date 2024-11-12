using FitnessTracker.Models;

namespace FitnessTracker.Repository
{
    public static class TrainerRepository
    {
        private static List<Trainer> _trainers = new List<Trainer>
    {
        new Trainer { TrainerId = 1, Name = "John Doe", Specialty = "Yoga", PhoneNumber = 1234567890 },
        new Trainer { TrainerId = 2, Name = "Jane Smith", Specialty = "Weightlifting", PhoneNumber = 9876543210 }
    };

        public static IEnumerable<Trainer> GetAllTrainers() => _trainers;

        public static Trainer GetTrainerById(int id) => _trainers.FirstOrDefault(t => t.TrainerId == id);

        public static void AddTrainer(Trainer trainer)
        {
            trainer.TrainerId = _trainers.Max(t => t.TrainerId) + 1;
            _trainers.Add(trainer);
        }

        public static void UpdateTrainer(Trainer trainer)
        {
            var existingTrainer = GetTrainerById(trainer.TrainerId);
            if (existingTrainer != null)
            {
                existingTrainer.Name = trainer.Name;
                existingTrainer.Specialty = trainer.Specialty;
                existingTrainer.PhoneNumber = trainer.PhoneNumber;
            }
        }

        public static void DeleteTrainer(int id) => _trainers.RemoveAll(t => t.TrainerId == id);
    }

}
