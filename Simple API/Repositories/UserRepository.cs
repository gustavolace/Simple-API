using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Simple_API.Data;
using Simple_API.Models;
using Simple_API.Repositories.Interfaces;

namespace Simple_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDataController _dbContext;
        public UserRepository(TaskDataController TaskDataController) 
        {
            _dbContext = TaskDataController;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel userbyid = await FindUserById(id);

            if (userbyid != null)
            {
                _dbContext.Remove(userbyid);
                await _dbContext.SaveChangesAsync();

                return true;    
            }
            throw new Exception($"Usuario {id} não encontrado");
        }

        public async Task<UserModel> FindUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> FindUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Insert(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userbyid = await FindUserById(id);

            if (userbyid != null)
            {
                userbyid.Name = user.Name;
                userbyid.Email = user.Email;

                _dbContext.Update(userbyid);
                await _dbContext.SaveChangesAsync();

                return userbyid;
            }
            throw new Exception($"Usuario {id} não encontrado");
        }
    }
}
