using MessageBus;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMessageBus, MessageBus.MessageBus>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var messageBus = app.Services.GetService<IMessageBus>();
messageBus.Consume(MessageKeys.POST_CREATED, (message) =>
{
    // do something with the message like sending emails
    Console.WriteLine(message);
    return Task.CompletedTask;
});

app.Run();
