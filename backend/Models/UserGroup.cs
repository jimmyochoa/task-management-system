using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class UserGroup
{
    public int UserGroupId { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
