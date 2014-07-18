using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class ContextView : View
    {
        public ContextView(SoftwareSystem system) : base(system) { }

        public string Type { get { return "SystemContext"; } }

        public override void Normalize()
        {
            foreach (var system in Model.SoftwareSystems)
                AddElement(system);

            foreach (var person in Model.People)
                AddElement(person);

            base.Normalize();
        }
    }
}
