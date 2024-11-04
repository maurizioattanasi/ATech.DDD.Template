using MediatR;
using Microsoft.Extensions.Logging;

namespace ATech.DDD.Template.Application.Version;

public class VersionQueryHandler : IRequestHandler<VersionQuery, VersionResult>
{
    private readonly ILogger<VersionQueryHandler> _logger;

    public VersionQueryHandler(ILogger<VersionQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task<VersionResult> Handle(VersionQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving Assembly Version...");

        var assemblyName = System.Reflection.Assembly.GetEntryAssembly()?.GetName();

        if (assemblyName is null)
        {
            throw new InvalidProgramException("Cannot retrieve the entry assembly name...");
        }

        var version = assemblyName.Version?.ToString() ?? string.Empty;

        return await Task.FromResult(new VersionResult(version));
    }
}

