using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Shows.Models;

namespace Tv_Shows.Repositories
{
    public class UserRepository : IUserRepository
    {
        
            private TvContext _userDbContext;

            public UserRepository(TvContext userDbContext)
            {
            _userDbContext = userDbContext;
            }

            public bool UserExists(int userId)
            {
                return _userDbContext.Users.Any(b => b.Id == userId);
            }

            public bool UserExists(string userIsbn)
            {
                return _userDbContext.Users.Any(b => b.Isbn == userIsbn);
            }

            public bool CreateUser( List<int> tvshowsId, User user)
            {
                
                var tvshows = _userDbContext.TvShows.Where(c => tvshowsId.Contains(c.Id)).ToList();

                
                foreach (var tvshow in tvshows)
                {
                    var userTvshow = new UserTvshow()
                    {
                        Tvshow = tvshow,
                        User = user
                    };
                    _userDbContext.Add(userTvshow);
                }

                _userDbContext.Add(user);

                return Save();
            }

            public bool DeleteUser(User user)
            {
                _userDbContext.Remove(user);
                return Save();
            }

            public User GetUser(int userId)
            {
                return _userDbContext.Users.Where(b => b.Id == userId).FirstOrDefault();
            }

            public User GetUser(string userIsbn)
            {
                return _userDbContext.Users.Where(b => b.Isbn == userIsbn).FirstOrDefault();
            }

            public ICollection<User> GetUsers()
            {
                return _userDbContext.Users.OrderBy(b => b.Name).ToList();
            }

            public bool IsDuplicateIsbn(int userId, string userIsbn)
            {
                var user = _userDbContext.Users.Where(b => b.Isbn.Trim().ToUpper() == userIsbn.Trim().ToUpper()
                                                    && b.Id != userId).FirstOrDefault();

                return user == null ? false : true;
            }

            public bool Save()
            {
                var saved = _userDbContext.SaveChanges();
                return saved >= 0 ? true : false;
            }

            public bool UpdateUser( List<int> tvshowId, User user)
            {
               var tvshows = _userDbContext.TvShows.Where(c => tvshowId.Contains(c.Id)).ToList();              
               var userTvShowsToDelete = _userDbContext.UserTvshows.Where(b => b.UserId == user.Id);

                _userDbContext.RemoveRange(userTvShowsToDelete);

               
                foreach (var tvshow in tvshows)
                {
                    var userTvshow = new UserTvshow()
                    {
                        Tvshow = tvshow,
                        User = user
                    };
                    _userDbContext.Add(userTvshow);
                }

                _userDbContext.Update(user);

                return Save();
            
        }
    }
}
