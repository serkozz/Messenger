using MassTransit;
using ProfileMicroservice.Data;
using ProfileMicroservice.Data.Models;
using Shared.Events;
using Microsoft.EntityFrameworkCore;

namespace ProfileMicroservice.Consumers;

/// <summary>
/// Потребитель, создающий профиль в ответ на событие регистрации нового пользователя из IdentityMicroservice
/// </summary>
public class IdentityCreatedEventConsumer(AppDbContext db) : IConsumer<IdentityCreatedEvent>
{
    private readonly AppDbContext _db = db;

    public async Task Consume(ConsumeContext<IdentityCreatedEvent> context)
    {
        var msg = context.Message;

        // Ищем профиль по UserId, который не является PK
        var existing = await _db.UserProfiles
            .FirstOrDefaultAsync(p => p.UserId == msg.UserId);

        if (existing != null)
        {
            Console.WriteLine($"[ProfileService] Профиль для {msg.UserId} уже существует.");
            return;
        }

        var newProfile = new UserProfileModel
        {
            UserId = msg.UserId,
        };

        _db.UserProfiles.Add(newProfile);
        await _db.SaveChangesAsync();

        Console.WriteLine($"[ProfileService] Профиль для {msg.Email} успешно создан! UserId: {msg.UserId}");
    }
}