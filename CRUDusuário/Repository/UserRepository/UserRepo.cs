using CRUDusuário.Data;
using CRUDusuário.Models;
using CRUDusuário.Repository.UserRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDusuário.Repository.UserRepository
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _dbContext;
        public UserRepo(DatabaseContext dbContext) {
        _dbContext = dbContext;
        }

        public async Task<User> Create(User user)
        {
             _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var booktodelete = await _dbContext.users.FindAsync(id);
            _dbContext.users.Remove(booktodelete);
             await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _dbContext.users.ToListAsync<User>();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;

           await _dbContext.SaveChangesAsync();
           
        }
    }
}
