using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class ComponentSegmentWalker : ElementSegmentWalker<ComponentSegmentWalker>
    {
        private readonly Component _component;

        public ComponentSegmentWalker(Component component) : base(component)
        {
            _component = component;
        }

        [Parse("tech (.*)")]
        public void SetTechnology(string technology)
        {
            _component.Technology = technology;
        }

        [Parse("implementation (.*)")]
        public void SetImplementationType(string implementationType)
        {
            _component.ImplementationType = implementationType;
        }

        [Parse("interface (.*)")]
        public void SetInterfaceType(string interfaceType)
        {
            _component.InterfaceType = interfaceType;
        }

        [Parse("container (.*)")]
        public void SetContainer(string tag)
        {
            var container = _component.Model.GetElementByName(tag) as Container;

            container.AddComponent(_component);
        }
    }
}
