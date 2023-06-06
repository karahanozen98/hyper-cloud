using Microsoft.AspNetCore.Http;

namespace Data.UnitOfWork
{
    public class UnitOfWorkMiddleware
{
        private readonly RequestDelegate _next;

        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            await _next.Invoke(context);
            unitOfWork.Save();
        }
    }
}
