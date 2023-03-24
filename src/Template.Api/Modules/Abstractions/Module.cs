namespace Template.Api.Modules.Abstractions;

/// <summary>
/// An abstract class used to define a Module.
/// </summary>
/// <typeparam name="TLoggerCategory"></typeparam>
public abstract class Module<TLoggerCategory> : IModule
{
    /// <summary>
    /// The logger.
    /// </summary>
    protected readonly ILogger<TLoggerCategory> _logger;

    protected Module(ILogger<TLoggerCategory> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public abstract void MapEndpoints(IEndpointRouteBuilder builder);
}

/// <summary>
/// Define a Module.
/// </summary>
public interface IModule
{
    /// <summary>
    /// Implement this one to map all endpoints needed.
    /// </summary>
    /// <param name="builder">The builder used to map endpoints</param>
    void MapEndpoints(IEndpointRouteBuilder builder);
}
