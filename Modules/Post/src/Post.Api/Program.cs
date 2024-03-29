using Post.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Data.UnitOfWork;
using Post.Repository.UnitOfWork;
using Post.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Logging.Middleware;
using Logging.Logger;
using MessageBus;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnection"));
    options.UseLazyLoadingProxies(true);
});
builder.Services.AddScoped<IUnitOfWork, PostUnitOfWork>();
builder.Services.AddScoped<PostService>();
builder.Services.AddSingleton<Logger>();
builder.Services.AddSingleton<IMessageBus, MessageBus.MessageBus>();


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"].ToString())),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoggerMiddleware>();
app.UseMiddleware<UnitOfWorkMiddleware>();

app.Run();
