

using Post.Repository.Context;

namespace Post.Repository.UnitOfWork
{
    public class PostUnitOfWork : Data.UnitOfWork.UnitOfWork
    {
        public PostUnitOfWork(ApplicationDbContext context) : base(context)
        {
        }
    }
}
