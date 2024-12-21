using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<TaskGroup> TaskGroups { get; set; } = new List<TaskGroup>();

    public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
}
