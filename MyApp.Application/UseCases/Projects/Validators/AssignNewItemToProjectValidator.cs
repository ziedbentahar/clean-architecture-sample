using FluentValidation;
using MyApp.Application.UseCases.Projects.Commands;

namespace MyApp.Application.UseCases.Projects.Validators;

public class AssignNewItemToProjectValidator : AbstractValidator<AssignNewItemToProject>
{
    public AssignNewItemToProjectValidator()
    {
        RuleFor(x => x.ItemTitle).NotNull().MaximumLength(100);
        RuleFor(x => x.ItemDescription).NotEmpty().MaximumLength(500);
        RuleFor(x => x.ProjectId).NotNull();
    }
    
}