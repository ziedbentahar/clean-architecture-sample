using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Core.ProjectAggregate.Events;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace MyApp.Domain.ProjectAggregate;


public class Project : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  private List<ToDoItem> _items = new List<ToDoItem>();
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  public PriorityStatus Priority { get; }

  public Project(string name, PriorityStatus priority)
  {
    Name = name;
    Priority = priority;
  }

  public void AddItem(ToDoItem newItem)
  {
    if (newItem == null) throw new ArgumentNullException(nameof(newItem));

    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    base.RegisterDomainEvent(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    if (newName == null) throw new ArgumentNullException(nameof(newName));
    Name = newName;
  }
}

public enum PriorityStatus
{
  Critical = 0,
  Backlog = 1,
  Bug = 2
}
