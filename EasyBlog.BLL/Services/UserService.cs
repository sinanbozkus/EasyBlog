using EasyBlog.BLL.Helpers;
using EasyBlog.BLL.Interfaces;
using EasyBlog.DAL.Contexts;
using EasyBlog.DAL.Repositories;
using EasyBlog.DAL.UnitOfWork;
using EasyBlog.Domain.Entities;

namespace EasyBlog.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork<EasyBlogContext> _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork<EasyBlogContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository =  _unitOfWork.GetRepository<User>();
        }

        public User GetUserById(int id)
        {
            return _userRepository.Get(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.Get(x => x.Username == username);
        }

        public bool VerifyPassword(User user, string password)
        {
            return HashHelper.VerifyHashedPassword(user.PasswordHash, password);
        }

        public void AddUser(User user, string password)
        {
            user.PasswordHash = HashHelper.HashPassword(password);

            _userRepository.Add(user);
            _unitOfWork.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var record = GetUserById(user.Id);
            record.UserType = user.UserType;
            record.Email = user.Email;
            record.Username = user.Username;

            _userRepository.Update(record);
            _unitOfWork.SaveChanges();
        }

        public void UpdatePassword(int userId, string password)
        {
            var hashedPassword = HashHelper.HashPassword(password);
            var record = GetUserById(userId);
            record.PasswordHash = hashedPassword;

            _userRepository.Update(record);
            _unitOfWork.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var record = GetUserById(id);

            _userRepository.Delete(record);
            _unitOfWork.SaveChanges();
        }
    }
}
