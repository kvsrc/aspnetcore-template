using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Template.Api.Boot.Extensions;

public static class ApiExplorerExtensions
{
    /// <summary>
    /// Add default services to explore apis.
    /// </summary>
    public static WebApplicationBuilder AddApiExplorers(this WebApplicationBuilder builder)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(ConfigureSwaggerGen);

        return builder;
    }

    private static void ConfigureSwaggerGen(SwaggerGenOptions options)
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "Template api page",
                Description = "Developers page where to find the apis."
            }
        );

        // Create a file for documenting the api with visual studio comments
        string fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
    }

    /// <summary>
    /// Configure services to use default api explorer services.
    /// </summary>
    public static WebApplication UseApiExplorers(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
