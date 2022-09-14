using MyApp.Domain.ProjectAggregate;

namespace MyApp.Infrastructure.DataAccess;

public class EfProjectRepository : IProjectRepository
{
    public async Task<Project> GetProjectById(int i)
    {
        return new Project("ceci est un test", PriorityStatus.Backlog) { Id = i };
    }

    public async Task UpdateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public async Task<Project> CreateNewProject(Project project)
    {
        throw new NotImplementedException();
    }
}