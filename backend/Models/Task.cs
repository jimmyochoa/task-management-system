using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<TaskGroup> TaskGroups { get; set; } = new List<TaskGroup>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
