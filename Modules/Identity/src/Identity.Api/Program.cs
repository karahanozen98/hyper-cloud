using Data.UnitOfWork;
using Identity.Application.Services;
using Identity.Repository.Context;
using Identity.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


builder.Services.AddScoped<IUnitOfWork, IdentityUnitOfWork>();
builder.Services.AddScoped<UserService>();

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

app.Run();
