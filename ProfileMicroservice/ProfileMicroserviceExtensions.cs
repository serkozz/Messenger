using MassTransit;
using Shared.Events;

namespace ProfileMicroservice;

public static class ProfileMicroserviceExtensions
{
    public static void MapProfileMicroservice(this IEndpointRouteBuilder app)
    {
        app.MapPost("", async (IPublishEndpoint publishEndpoint) =>
        {
            await publishEndpoint.Publish("");
            return Results.Ok(new { Message = "Profile created" });
        });
    }
}