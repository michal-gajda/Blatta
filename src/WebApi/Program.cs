namespace Blatta.WebApi;

using Blatta.Application;
using Blatta.Infrastructure;

public sealed class Program
{
    private Program()
    {
    }

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Blatta API v1");
            });
        }

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}
