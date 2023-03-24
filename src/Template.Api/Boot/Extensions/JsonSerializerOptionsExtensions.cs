using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Template.Common;

namespace Template.Api.Boot.Extensions;

public static class JsonSerializerOptionsExtensions
{
    /// <summary>
    /// Add Json serializer options.
    /// </summary>
    public static WebApplicationBuilder AddJsonSerializerOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton(Defaults.CommonJsonOptions);

        // in the api enpoints the enums will be converted from enum to string
        // and from string to enum
        builder.Services.Configure<JsonOptions>(opt =>
        {
            opt.SerializerOptions.Converters.Add(
                Defaults.CommonJsonOptions.Converters.First(
                    c => c.GetType() == typeof(JsonStringEnumConverter)
                )
            );
        });

        return builder;
    }
}
