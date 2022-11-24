using Microsoft.EntityFrameworkCore;
using Stock_4.Models;
using Stock4.DataT;
using Stock4.Models;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;

namespace Stock_4.Repositories
{
    public class UserPortfolioRepository : IUserPortfolioRepository
    {
        private readonly StockContext _context;
        public UserPortfolioRepository(StockContext context)
        {
            _context = context;
        }
        public void Create(UserPortfolio userPortfolio)
        {
            _context.userPortfolios.Add(userPortfolio);
            _context.SaveChanges();
        }
        public List<UserPortfolio> GetUserPortfolios(int UserId)
        {
            return _context.userPortfolios
                            .Include(s => s.Stock)
                            .Where(s => s.UserId == UserId)
                            .ToList();
        }

        UserPortfolio IUserPortfolioRepository.GetUserPortfolio(int Id)
        {
            return _context.userPortfolios.FirstOrDefault(w => w.Id == Id);
        }

        public void Remove(UserPortfolio userPortfolio)
        {
            _context.userPortfolios.Remove(userPortfolio);
            _context.SaveChanges();
        }
    }
}
