using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class Container : Element
    {
        private readonly IList<Component> _components = new List<Component>();

        public string Technology { get; set; }
        public string Type { get { return "Container"; } }
        public IEnumerable<Component> Components { get { return _components; } }

        internal SoftwareSystem Parent { get; set; }

        public Component AddComponent(string name)
        {
            var component = Model.AddComponent(name);
            AddComponent(component);
            return component;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
            component.Location = this.Location;
        }
    }
}
