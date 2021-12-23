using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUserById(int id);
    public Task<int> CreateUser(User user);
    public Task<int> UpdateUser(User user);
    public Task<int> DeleteUser(User user);
}