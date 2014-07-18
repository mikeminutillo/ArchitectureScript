using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArchitectureScript.Parsing
{
    class ModelSegmentWalker : SegmentWalkerBase<ModelSegmentWalker>
    {
        private readonly ArchitectureScript.Model.Model _model;

        public ModelSegmentWalker(ArchitectureScript.Model.Model model)
        {
            _model = model;
        }

        [Parse("internal system (.*)")]
        [Parse("system (.*)")]
        public SystemSegmentWalker AddInternalSystem(string tag)
        {
            var system = _model.AddSoftwareSystem("Internal", tag);
            return new SystemSegmentWalker(system);
        }

        [Parse("external system (.*)")]
        public SystemSegmentWalker AddExternalSystem(string tag)
        {
            var system = _model.AddSoftwareSystem("External", tag);
            return new SystemSegmentWalker(system);
        }

        [Parse("person (.*)")]
        [Parse("internal person (.*)")]
        public PersonSegmentWalker AddInternalPerson(string tag)
        {
            var person = _model.AddPerson("Internal", tag);
            return new PersonSegmentWalker(person);
        }

        [Parse("external person (.*)")]
        public PersonSegmentWalker AddExternalPerson(string tag)
        {
            var person = _model.AddPerson("External", tag);
            return new PersonSegmentWalker(person);
        }

        [Parse("container (.*)")]
        public ContainerSegmentWalker AddContainer(string tag)
        {
            var container = _model.AddContainer(tag);
            return new ContainerSegmentWalker(container);
        }

        [Parse("component (.*)")]
        public ComponentSegmentWalker AddComponent(string tag)
        {
            var component = _model.AddComponent(tag);
            return new ComponentSegmentWalker(component);
        }

        [Parse("view context (.*)")]
        public ViewSegmentWalker AddContextView(string system)
        {
            var view = _model.AddContextView(system);
            return new ViewSegmentWalker(view);
        }

        [Parse("view containers (.*)")]
        public ViewSegmentWalker AddContainersView(string system)
        {
            var view = _model.AddContainerView(system);
            return new ViewSegmentWalker(view);
        }

        [Parse("view components (.*)")]
        public ViewSegmentWalker AddComponentsView(string container)
        {
            var view = _model.AddComponentView(container);
            return new ViewSegmentWalker(view);
        }
    }
}
