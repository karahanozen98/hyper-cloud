using Identity.Repository.Context;

namespace Identity.Repository.UnitOfWork
{
    public class IdentityUnitOfWork : Data.UnitOfWork.UnitOfWork
    {
        public IdentityUnitOfWork(ApplicationDbContext context) : base(context)
        {

        }
    }
}
