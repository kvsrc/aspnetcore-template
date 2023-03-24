using System.Text.Json;
using System.Text.Json.Serialization;

namespace Template.Common;

public static class Defaults
{
    static Defaults()
    {
        JsonSerializerOptions _jso = new() { PropertyNameCaseInsensitive = true, };
        _jso.Converters.Add(new JsonStringEnumConverter());

        CommonJsonOptions = _jso;
    }

    /// <summary>
    /// A default <see cref="JsonSerializerOptions"/> to with enum => string
    /// and case insensitive properties.
    /// </summary>
    public static JsonSerializerOptions CommonJsonOptions { get; }
}
