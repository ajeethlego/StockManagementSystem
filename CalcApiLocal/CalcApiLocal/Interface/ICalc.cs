using CalcApiLocal.Models;

namespace CalcApiLocal.Interface
{
    public interface ICalc
    {
        CalcRes GetCalcId(int id);
        List<CalcRes> GetCalc();
        float Create(CalcRes calcRes)
        {
            return calcRes.TotalPrice;
        }
        //void Update(CalcRes calcRes);
        void Delete(CalcRes id);

    }
}
