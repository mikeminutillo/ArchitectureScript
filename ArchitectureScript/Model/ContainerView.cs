using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class ContainerView : View
    {
        public ContainerView(SoftwareSystem system) : base(system)
        {
            Name = String.Format("{0} - Containers", system.Name);
        }

        public string Type { get { return "Container"; } }

        public override void Normalize()
        {
            foreach (var system in Model.SoftwareSystems.Where(x => x.Id != SoftwareSystemId))
                AddElement(system);

            foreach (var person in Model.People)
                AddElement(person);

            foreach (var container in System.Containers)
                AddElement(container);

            base.Normalize();
        }
    }
}
