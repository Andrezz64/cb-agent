using cb_agent.Repository.Classes;
using cb_agent.Repository.Interfaces;
using cb_agent.Services.Interfaces;
using cb_agent.Utils;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ServicesBuilders.InjectCustomServicesAsDependency(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("--> Launching Agent in development mode");
    Console.WriteLine("--> The Service Auto Start feature is disabled for this mode");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    using (var scope = app.Services.CreateScope())
    {
        var handler = scope.ServiceProvider.GetRequiredService<IServiceHandlerService>();

        // Usar a instância da classe
        handler.AutoStartServices();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
