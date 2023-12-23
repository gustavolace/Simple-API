using Simple_API.Models;

namespace Simple_API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindUsers();
        Task<UserModel> FindUserById(int id);
        Task<UserModel> Insert(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
