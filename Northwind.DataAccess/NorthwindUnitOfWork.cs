using Repository.Pattern.DataContext;
using Repository.Pattern.EfCore;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork :UnitOfWork, INorthwindUnitOfWork
    {
        public NorthwindUnitOfWork(IDataContextAsync dataContext) : base(dataContext)
        {
        }
    }
}