
using Stock4.Models;
using System.Collections.Generic;

namespace Stock4.Repositories
{
    public interface IUserWatchlist1Repository
    {
        UserWatchlist1 GetUserWatchlist1s(int Id);
        void Create(UserWatchlist1 userWatchlist1);
        List<UserWatchlist1> GetUserWatchlist1(int UserId);
        void Remove(UserWatchlist1 userWatchlist1);
    }
}
