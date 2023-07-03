using CRUDusuário.Models;

namespace CRUDusuário.Repository.UserRepo
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> Get();

        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task Delete(int id);
        Task Update(User user);
    }
}
