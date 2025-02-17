﻿using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class PermissionsProfilesWebModule
{
    public int PermissionProfileWebModuleId { get; set; }

    public int ProfileId { get; set; }

    public int WebModuleId { get; set; }

    public bool? PermissionProfileWebModuleAccess { get; set; }

    public bool? PermissionProfileWebModuleCreate { get; set; }

    public bool? PermissionProfileWebModuleUpdate { get; set; }

    public bool? PermissionProfileWebModuleDelete { get; set; }

    public bool? PermissionProfileWebModuleDownload { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual WebModule WebModule { get; set; } = null!;
}
