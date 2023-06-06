using Post.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Data.UnitOfWork;
using Post.Repository.UnitOfWork;
using Post.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnection")));
builder.Services.AddScoped<IUnitOfWork, PostUnitOfWork>();
builder.Services.AddScoped<PostService>();


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

app.UseMiddleware<UnitOfWorkMiddleware>();

app.Run();

// dotnet add package .\Modules\Post\src\Post.Api\Post.Api  Microsoft.EntityFrameworkCore.Design

