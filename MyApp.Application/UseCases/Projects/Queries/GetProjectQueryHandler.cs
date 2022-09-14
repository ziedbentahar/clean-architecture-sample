using MyApp.Application.UseCases.Projects.Commands;
using MyApp.Domain.ProjectAggregate;

namespace MyApp.Application.UseCases.Projects.Queries;

using Clean.Architecture.Core.ProjectAggregate;
using FluentValidation;
using MediatR;


public class GetProjectByIdQuery : IRequest<Project>
{
    public int ProjectId { get; set; }
    
    
}

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Task<Project> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
    {
        return _projectRepository.GetProjectById(query.ProjectId);
    }
}