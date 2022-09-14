using MediatR;
using MyApp.Domain.ProjectAggregate;

namespace MyApp.Application.UseCases.Projects.Commands;

public class CreateNewProject : IRequest<int>
{
    public string Name { get; set; }
}

public class CreateNewProjectHandler : IRequestHandler<CreateNewProject, int>
{
    private readonly IProjectRepository _projectRepository;

    public CreateNewProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
        
    
    public async Task<int> Handle(CreateNewProject request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Name, PriorityStatus.Backlog);
        var createdProject = await _projectRepository.CreateNewProject(project);

        return createdProject.Id;
    }
}