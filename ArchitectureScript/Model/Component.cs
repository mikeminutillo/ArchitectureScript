using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class Component : Element
    {
        public string Type { get { return "Component"; } }
        public string Technology { get; set; }
        public string ImplementationType { get; set; }
        public string InterfaceType { get; set; }
    }
}
