using Intern_Alta;
using Intern_Alta.Data;
using Intern_Alta.Services;
using Intern_Alta.Services.Configuration;
using Intern_Alta.Services.Documents;
using Intern_Alta.Services.DocumentTypes;
using Intern_Alta.Services.Flights;
using Intern_Alta.Services.Permissions;
using Intern_Alta.Services.Roles;
using Intern_Alta.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IDocTypeService, DocTypeService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IConfigService, ConfigService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService,RoleService>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
