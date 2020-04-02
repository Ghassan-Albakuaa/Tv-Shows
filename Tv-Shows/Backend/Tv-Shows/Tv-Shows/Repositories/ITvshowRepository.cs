using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Shows.Models;

namespace Tv_Shows.Repositories
{
    public interface ITvshowRepository
    {
        ICollection<Tvshow> GetTvshows();
        Tvshow GetTvshow(int tvshowId);
        ICollection<Tvshow> GetAllTvshowsForUser(int userId);
        ICollection<User> GetAllUsersForTvshow(int tvshowId);
        bool TvshowExists(int tvshowId);
        bool IsDuplicateTvshowName(int tvshowId, string tvshowName);

        bool CreateTvshow(Tvshow tvshow);
        bool UpdateTvshow(Tvshow tvshow);
        bool DeleteTvshow(Tvshow tvshow);
        bool Save();
    }
}
