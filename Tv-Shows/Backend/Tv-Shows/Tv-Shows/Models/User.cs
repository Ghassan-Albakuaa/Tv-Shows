using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Shows.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Isbn { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<UserTvshow> UserTvshows { get; set; }
    }
}
