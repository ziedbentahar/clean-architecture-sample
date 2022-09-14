namespace MyApp.Domain.ProjectAggregate;

public interface IProjectRepository
{
    Task<Project> GetProjectById(int i);
    Task UpdateProject(Project project);
    Task<Project> CreateNewProject(Project project);
}