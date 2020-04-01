using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Shows.Models
{
    public class UserTvshow
    {
        public int Id { get; set; }

        public Tvshow Tvshow { get; set; }
        public int TvshowId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
