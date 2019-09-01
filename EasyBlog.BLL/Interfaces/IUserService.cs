using EasyBlog.Domain.Entities;

namespace EasyBlog.BLL.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void AddUser(User user, string password);
        void UpdateUser(User user);
        void UpdatePassword(int userId, string password);
        void DeleteUser(int id);
        bool VerifyPassword(User user, string password);
    }
}
