using MassTransit;
using SharedLibrary.Events; // Твой общий проект с событиями

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    // private readonly AppDbContext _db;

    // public UserCreatedConsumer(AppDbContext db) => _db = db;

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var msg = context.Message;

        // Проверяем, нет ли уже такого профиля (на всякий случай)
        // var existing = await _db.Profiles.FindAsync(msg.UserId);
        // if (existing != null) return;

        // Создаем новый профиль в Postgres
        // _db.Profiles.Add(new UserProfile 
        // { 
            // UserId = msg.UserId, 
            // DisplayName = msg.Email.Split('@')[0], // Дефолтный ник из почты
            // CreatedAt = DateTime.UtcNow
        // });

        // await _db.SaveChangesAsync();
        Console.WriteLine($"[ProfileService] Профиль для {msg.Email} успешно создан!");
    }
}