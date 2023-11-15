using System.Security.Cryptography;
using System.Text;
using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public class UserRepository : IUserRepository
{

    public List<User> GetAll()
    {
        using var dbContext = new RealEstateAgencyApiContext();
        return dbContext.Users.ToList();
    }

    public User? Login(string userNameOrEmail, string password)
    {
        using var dbContext = new RealEstateAgencyApiContext();
        return dbContext.Users.
            FirstOrDefault(u => (u.Username == userNameOrEmail || u.Email == userNameOrEmail) && u.Password == Hash(password));
    }

    public void Add(User user)
    {
        using var dbContext = new RealEstateAgencyApiContext();
        var hashedPwUser = user;
        hashedPwUser.Password = Hash(user.Password);
        dbContext.Add(hashedPwUser);
        dbContext.SaveChanges();
    }

    public void Delete(int userId)
    {
        using var dbContext = new RealEstateAgencyApiContext();
        User userToRemove = new User() {Id = userId};
        dbContext.Remove(userToRemove);
        dbContext.SaveChanges();
    }

    public void Update(int userId, string newPassword)
    {
        using var dbContext = new RealEstateAgencyApiContext();
        var userToUpdate = dbContext.Users.Find(userId);
        userToUpdate.Password = Hash(newPassword);
        dbContext.Update(userToUpdate);
        dbContext.SaveChanges();
    }

    private string Hash(string pw)
    {
        StringBuilder Sb = new StringBuilder();

        using (SHA256 hash = SHA256Managed.Create()) {
            Encoding enc = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(enc.GetBytes(pw));

            foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));
        }

        return Sb.ToString();
    }
}