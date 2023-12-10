using Microsoft.EntityFrameworkCore;
using MinimalApiDemos.APIs;
using MinimalApiDemos.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDbContext>(opt =>
opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
app.AddApiExplorer();

app.Run();
