using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.DTOs;
using MyApp.Application.UseCases.Projects.Queries;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ILogger<ProjectController> _logger;
    private readonly IMediator _mediator;

    public ProjectController(ILogger<ProjectController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "Get Project By Id")]
    public async Task<ProjectDto> Get(int ProjectId)
    {
        var project = await _mediator.Send(new GetProjectByIdQuery { ProjectId = ProjectId });

        return new ProjectDto
        {
            Name = project.Name,
            Id = project.Id
        };
    }
}