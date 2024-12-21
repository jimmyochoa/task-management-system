using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class TaskGroup
{
    public int TaskGroupId { get; set; }

    public int GroupId { get; set; }

    public int TaskId { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
