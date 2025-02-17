﻿using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class UserProfile
{
    public int UserProfileId { get; set; }

    public int? ProfileId { get; set; }

    public int? UserId { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual User? User { get; set; }
}
