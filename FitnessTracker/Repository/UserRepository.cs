using FitnessTracker.Models;

namespace FitnessTracker.Repository
{
    public static class UserRepository
    {
        public static List<User> users = new List<User>();
        private static int nextId = 1;

        // Create
        public static void AddUser(User user)
        {
            user.UserId = nextId++;
            users.Add(user);
        }

        // Read
        public static List<User> GetAllUsers()
        {
            return users;
        }

        public static User GetUserById(int userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }

        // Update
        public static void UpdateUser(User updatedUser)
        {
            var existingUser = GetUserById(updatedUser.UserId);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Age = updatedUser.Age;
                existingUser.Gender = updatedUser.Gender;
                existingUser.Address = updatedUser.Address;
                existingUser.EmailId = updatedUser.EmailId;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;
                existingUser.SubscriptionType = updatedUser.SubscriptionType;
                existingUser.StartDate = updatedUser.StartDate;
                existingUser.EndDate = updatedUser.EndDate;
            }
        }


        // Delete
        public static void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }

    public class UserService
    {
        public IEnumerable<User> GetUsers()
        {
            return UserRepository.GetAllUsers();
        }

        public Dictionary<int, int> GetNewUsersPerMonth()
        {
            return UserRepository.GetAllUsers()
                .GroupBy(u => new { u.StartDate.Year, u.StartDate.Month })
                .ToDictionary(
                    g => g.Key.Year * 100 + g.Key.Month, // Using YYYYMM as the key
                    g => g.Count()
                );
        }
    }

}
