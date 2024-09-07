using System.Security.Cryptography;
using System.Text;

namespace KeyedSemaphoreImplementation.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        private User()
        {

        }

        public User(string email, string password)
        {
            Email = email;
            SetPassword(password);
        }

        public void SetPassword(string password)
        {
            using var hmac = new HMACSHA256();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
