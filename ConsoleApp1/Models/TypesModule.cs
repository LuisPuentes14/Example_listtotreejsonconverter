using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class TypesModule
{
    public int TypeModuleId { get; set; }

    public string? TypeModuleName { get; set; }

    public virtual ICollection<WebModule> WebModules { get; set; } = new List<WebModule>();
}
