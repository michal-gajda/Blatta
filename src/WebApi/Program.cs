namespace Blatta.WebApi;

using Blatta.Application;
using Blatta.Infrastructure;

public sealed class Program
{
    private Program()
    {
    }

    public static async Task<int> Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            Args = args,
            ContentRootPath = AppContext.BaseDirectory,
        });

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

        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            await app.RunAsync();
        }
        catch (OperationCanceledException)
        {
            //
        }
        catch (Exception exception)
        {
            logger.LogCritical(exception, "An unhandled exception occurred while running the application.");

            return 1;
        }

        return 0;
    }
}
