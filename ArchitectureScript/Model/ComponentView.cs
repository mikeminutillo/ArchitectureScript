using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class ComponentView : View
    {
        private readonly Container _container;

        public ComponentView(Container container) : base(container.Parent)
        {
            _container = container;
            Name = String.Format("{0} - {1} - Components", container.Parent.Name, _container.Name);
        }
        

        public int ContainerId { get { return _container.Id;  } }
        public string Type { get { return "Component"; } }

        public override void Normalize()
        {
            foreach (var system in Model.SoftwareSystems.Where(x => x.Id != SoftwareSystemId))
                AddElement(system);

            foreach (var container in System.Containers.Where(x => x.Id != _container.Id))
                AddElement(container);
            
            foreach(var component in _container.Components)
                AddElement(component);

            base.Normalize();
        }
    }
}
