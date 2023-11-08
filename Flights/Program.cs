using Flights.Data;
using Flights.Data.DataServices;
using Flights.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddScoped<ITicketDataService, TicketDataService>();
builder.Services.AddScoped<IPassengerDataService, PassengerDataService>();
builder.Services.AddScoped<IDocumentDataService, DocumentDataService>();
builder.Services.AddDbContext<DefaultContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

