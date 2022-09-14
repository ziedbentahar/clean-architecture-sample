using Clean.Architecture.Core.ProjectAggregate;
using FluentValidation;
using MediatR;
using MyApp.Domain.ProjectAggregate;

namespace MyApp.Application.UseCases.Projects.Commands;

public class AssignNewItemToProject : IRequest
{
    public int ProjectId { get; set; }
    
    public string ItemTitle { get; set; }
    public string ItemDescription { get; set; }
}

public class AssingNewItemToProjectHandler : IRequestHandler<AssignNewItemToProject>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IValidator<AssignNewItemToProject> _validator;

    public AssingNewItemToProjectHandler(IProjectRepository projectRepository, IValidator<AssignNewItemToProject> validator)
    {
        _projectRepository = projectRepository;
        _validator = validator;
    }
        
    
    public async Task<Unit> Handle(AssignNewItemToProject request, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);

        if (!result.IsValid) throw new ArgumentException(nameof(request));
        
        var project = await _projectRepository.GetProjectById(request.ProjectId);
        project.AddItem(new ToDoItem { Description = request.ItemDescription, Title = request.ItemTitle});

        await _projectRepository.UpdateProject(project);
        
        return Unit.Value;

    }
}