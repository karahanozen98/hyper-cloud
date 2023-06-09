using Bff.Mobile.Api.Services;
using Identity.Abstraction.RemoteCall;
using Post.Abstraction.RemoteCall;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddRefitClient<IPostRemoteCall>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7093"));

builder.Services
     .AddRefitClient<IUserRemoteCall>()
     .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7120"));

builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<PostService>();


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
