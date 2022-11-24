using Stock_4.Models;
using Stock4.Models;

namespace Stock_4.Repositories
{
    public interface IUserPortfolioRepository
    {
        UserPortfolio GetUserPortfolio(int Id);
        void Create(UserPortfolio userPortfolio);
        List<UserPortfolio> GetUserPortfolios(int UserId);
        void Remove(UserPortfolio userPortfolio);
    }
}
