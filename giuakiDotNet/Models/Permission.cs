﻿using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public string? PermissionGroup { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
