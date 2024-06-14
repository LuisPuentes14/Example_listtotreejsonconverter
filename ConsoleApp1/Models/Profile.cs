using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public string? ProfileName { get; set; }

    public virtual ICollection<PermissionsProfilesWebModule> PermissionsProfilesWebModules { get; set; } = new List<PermissionsProfilesWebModule>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
