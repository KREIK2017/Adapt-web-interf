namespace RESTwebAPI.Models
{
    public class UserData
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Іван",
                LastName = "Петров",
                Email = "ivan@example.com",
                DateOfBirth = new DateTime(1990, 5, 15),
                Password = "asdasdasd",
                LastLoginDate = DateTime.Now.AddDays(-1),
                FailedLoginAttempts = 0
            },
            new User
            {
                Id = 2,
                FirstName = "Марія",
                LastName = "Іванова",
                Email = "maria@example.com",
                DateOfBirth = new DateTime(2000, 10, 25),
                Password = "marianacross10",
                LastLoginDate = DateTime.Now.AddDays(-3),
                FailedLoginAttempts = 2
            },
            new User
            {
                Id = 3,
                FirstName = "Максим",
                LastName = "Мичко",
                Email = "maxim@example.com",
                DateOfBirth = new DateTime(2004, 5, 5),
                Password = "qwerty123",
                LastLoginDate = new DateTime(2024,3,21),
                FailedLoginAttempts = 50
            },
        };
    }
}
