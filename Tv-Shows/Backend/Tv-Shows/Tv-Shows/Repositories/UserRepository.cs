using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Shows.Models;

namespace Tv_Shows.Repositories
{
    public interface UserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        User GetUser(string userIsbn);
        decimal GetUserRating(int userId);
        bool UserExists(int userId);
        bool UserExists(string userIsbn);
        bool IsDuplicateIsbn(int userId, string userIsbn);
        bool CreateUser(List<int> authorsId, List<int> categoriesId, User user);
        bool UpdateUser(List<int> authorsId, List<int> categoriesId, User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
