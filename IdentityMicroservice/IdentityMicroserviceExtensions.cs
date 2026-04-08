using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Shared.Events;

namespace IdentityMicroservice;

public static class IdentityMicroserviceExtensions
{
    public static void MapIdentityMicroservice(this IEndpointRouteBuilder app)
    {
        var identityGroup = app.MapGroup("/identity");
        identityGroup.MapIdentityApi<IdentityUser>();

        app.MapPost("/auth/register", async (RegisterRequest model, UserManager<IdentityUser> userManager, IPublishEndpoint publishEndpoint) =>
        {
            var isEmailValid = Validators.ValidateEmail(model.Email);

            if (!isEmailValid)
                return Results.BadRequest(new { Message = "Email имеет неверный формат" });

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await publishEndpoint.Publish(new IdentityCreatedEvent(user.Id, user.Email));
                return Results.Ok(new { Message = "User registered and profile event sent" });
            }

            return Results.BadRequest(result.Errors);
        });
    }
}