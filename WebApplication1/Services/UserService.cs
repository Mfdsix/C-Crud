using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> CreateUser(User user)
    {
        return await _userRepository.CreateAsync(user);
    }

    public async Task<int> DeleteUser(User user)
    {
        return await _userRepository.DeleteAsync(user);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<int> UpdateUser(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }
}