using MediatR;

namespace ATech.DDD.Template.Application.Version;

public record VersionQuery : IRequest<VersionResult>;

