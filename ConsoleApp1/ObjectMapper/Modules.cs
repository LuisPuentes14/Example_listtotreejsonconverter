using ListToTreeJsonConverter.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ObjectMapper
{
    public class Modules : TreeBuilder
    {
        public int WebModuleId { get; set; }

        public int? WebModuleFather { get; set; }

        public string? WebModuleTitle { get; set; }

        public string? WebModuleUrl { get; set; }

    }
}
