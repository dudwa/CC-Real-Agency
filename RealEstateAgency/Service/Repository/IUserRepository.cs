using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public interface IUserRepository
{
    public User? Login(string userNameOrEmail, string password);
    void Add(User user);
    void Delete(int id);
    void Update(string newPassword);

}
