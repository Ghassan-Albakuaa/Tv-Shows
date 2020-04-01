using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Shows.Models
{
    public class Tvshow
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserTvshow> UserTvshows { get; set; }
    }
}
