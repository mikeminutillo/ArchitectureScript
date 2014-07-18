using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class SoftwareSystem : Element
    {
        private IList<Container> _containers = new List<Container>();

        public string Type { get { return "SoftwareSystem"; } }

        public Container AddContainer(string name, string description, string technology)
        {
            var container = Model.AddContainer(name);
            AddContainer(container);
            return container;
        }

        public void AddContainer(Container container)
        {
            container.Location = this.Location;
            container.Parent = this;
            _containers.Add(container);            
        }


        public IEnumerable<Container> Containers { get { return _containers; } }
    }
}
