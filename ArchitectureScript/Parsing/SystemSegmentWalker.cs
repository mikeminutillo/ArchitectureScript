using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class SystemSegmentWalker : ElementSegmentWalker<SystemSegmentWalker>
    {
        private readonly SoftwareSystem _system;

        public SystemSegmentWalker(SoftwareSystem system) : base(system)
        {
            _system = system;
        }

        [Parse("container (.*)")]
        public ContainerSegmentWalker AddContainer(string tag)
        {
            var container = _system.AddContainer(tag, null, null);
            return new ContainerSegmentWalker(container);
        }
    }
}
