using Repository.Pattern.DataContext;
using Repository.Pattern.EfCore;

namespace WebApi.DataAccess
{
    public class NamosUnitOfWork : UnitOfWork, INamosUnitOfWork
    {
        public NamosUnitOfWork(IDataContextAsync dataContext) : base(dataContext)
        {
        }
    }
}