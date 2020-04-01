using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Shows.Models;

namespace Tv_Shows
{
    public static class SeedingDb
    {
        public static void SeedDataContext(this TvContext context)
        {
            var userTvshows = new List<UserTvshow>()
            {
               new UserTvshow()
                  {
                    User = new User()
                    {
                        Name = "Ghassan",
                        Image = "user1.jpg",
                        Password = "123456",
                    },
                     Tvshow = new Tvshow()
                    {
                        Name = "the end",
                        Image = "tv1.jpg",
                        Content = "123456",
                    }


                  }

            };


            //Comment = new Comment()
            //{
            //    Body = "Ghassan",
            //    Rating = "5",

            //};
            context.UserTvshows.AddRange(userTvshows);
            context.SaveChanges();
        }
    };

    
}
