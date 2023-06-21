using Data.UnitOfWork;
using Identity.Application.Services;
using Identity.Repository.Context;
using Identity.Repository.UnitOfWork;
using Logging.Logger;
using Logging.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IUnitOfWork, IdentityUnitOfWork>();
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<Logger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoggerMiddleware>();
app.UseMiddleware<UnitOfWorkMiddleware>();

app.Run();
