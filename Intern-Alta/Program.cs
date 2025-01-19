using Intern_Alta;
using Intern_Alta.Data;
using Intern_Alta.Services;
using Intern_Alta.Services.Documents;
using Intern_Alta.Services.DocumentTypes;
using Intern_Alta.Services.Flights;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IDocTypeService, DocTypeService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();


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
