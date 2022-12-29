using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock4.DataT;
using Stock4.Models;


namespace Stock4.Repositories
{
    public class UserWatchlist1Repository : IUserWatchlist1Repository
    {
        private readonly StockContext _context;
        public UserWatchlist1Repository(StockContext context)
        {
            _context = context;
        }
        public void Create(UserWatchlist1 userWatchlist1)
        {
            _context.userWatchlist1s.Add(userWatchlist1);
            _context.SaveChanges();

            
        }
        public List<UserWatchlist1> GetUserWatchlist1(int UserId)
        {
            return _context.userWatchlist1s
                .Include(s => s.Stock)
                .Where(s => s.UserId == UserId)
                .ToList();
        }
        UserWatchlist1 IUserWatchlist1Repository.GetUserWatchlist1s(int Id)
        {
            return _context.userWatchlist1s.FirstOrDefault(w => w.Id == Id);
        }

        public void Remove(UserWatchlist1 userWatchlist1)
        {
            _context.userWatchlist1s.Remove(userWatchlist1);
            _context.SaveChanges();
        }


    }
}
