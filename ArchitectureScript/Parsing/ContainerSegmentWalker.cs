using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class ContainerSegmentWalker : ElementSegmentWalker<ContainerSegmentWalker>
    {
        private readonly Container _container;

        public ContainerSegmentWalker(Container container) : base(container)
        {
            _container = container;
        }

        [Parse("tech (.*)")]
        public void SetTechnology(string technology)
        {
            _container.Technology = technology;
        }

        [Parse("component (.*)")]
        public ComponentSegmentWalker AddComponent(string tag)
        {
            var component = _container.AddComponent(tag);
            return new ComponentSegmentWalker(component);
        }

        [Parse("system (.*)")]
        public void SetSystem(string tag)
        {
            var system = _container.Model.GetElementByName(tag) as SoftwareSystem;
            system.AddContainer(_container);
        }
    }
}
