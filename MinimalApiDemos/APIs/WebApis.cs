using Microsoft.EntityFrameworkCore;
using MinimalApiDemos.Models;

namespace MinimalApiDemos.APIs;

internal static class WebApis
{
    internal static void AddApiExplorer(this WebApplication app)
    {

        app.MapPost("/api/users", async (List<User> users, UserDbContext db) =>
        {
            await db.Users.AddRangeAsync(users);
            await db.SaveChangesAsync();
            return Results.Accepted();
        });

        app.MapGet("/api/users", async (UserDbContext db) =>
        {
            return await db.Users.ToListAsync();
        });

        app.MapGet("/api/users/{id}", async (int id, UserDbContext db) =>
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        });
    }
}
