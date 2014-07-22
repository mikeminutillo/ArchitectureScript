using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class Model
    {
        private readonly IList<Element> _elements = new List<Element>();
        private readonly IList<View> _views = new List<View>();
        private readonly object _idLock = new object();

        public IEnumerable<SoftwareSystem> SoftwareSystems { get { return _elements.OfType<SoftwareSystem>().ToList(); } }
        public IEnumerable<Person> People { get { return _elements.OfType<Person>().ToList(); } }
        public IEnumerable<ContextView> SystemContextViews { get { return _views.OfType<ContextView>().ToList(); } }
        public IEnumerable<ContainerView> ContainerViews { get { return _views.OfType<ContainerView>().ToList(); } }
        public IEnumerable<ComponentView> ComponentViews { get { return _views.OfType<ComponentView>().ToList(); } }

        public Element GetElementByName(string name)
        {
            return _elements.SingleOrDefault(x => x.Name == name);
        }

        public void Normalise()
        {
            foreach (var element in _elements)
            {
                element.Normalise();
            }

            foreach (var view in _views)
            {
                view.Normalize();
            }
        }

        public SoftwareSystem AddSoftwareSystem(string location, string name)
        {
            var system = new SoftwareSystem
            {
                Id = GetId(),
                Location = location,
                Name = name,
                Model = this
            };

            _elements.Add(system);

            return system;
        }

        private int GetId()
        {
            lock (_idLock)
                return _elements.Select(x => x.Id).Concat(new[] { 0 }).Max() + 1;
        }

        public Person AddPerson(string location, string name)
        {
            var person = new Person
            {
                Id = GetId(),
                Location = location,
                Name = name,
                Model = this
            };

            _elements.Add(person);

            return person;
        }

        public Container AddContainer(string name)
        {
            var container = new Container
            {
                Id = GetId(),
                Name = name,
                Model = this
            };

            _elements.Add(container);

            return container;
        }

        public Component AddComponent(string name)
        {
            var component = new Component
            {
                Id = GetId(),
                Name = name,
                Model = this
            };

            _elements.Add(component);

            return component;
        }

        public ContextView AddContextView(string system)
        {
            var softwareSystem = GetElementByName(system) as SoftwareSystem;
            var contextView = new ContextView(softwareSystem);
            contextView.Model = this;
            _views.Add(contextView);
            return contextView;
        }

        public ContainerView AddContainerView(string system)
        {
            var softwareSystem = GetElementByName(system) as SoftwareSystem;
            var containerView = new ContainerView(softwareSystem);
            containerView.Model = this;
            _views.Add(containerView);
            return containerView;
        }

        public ComponentView AddComponentView(string tag)
        {
            var container = GetElementByName(tag) as Container;
            var componentView = new ComponentView(container);
            componentView.Model = this;
            _views.Add(componentView);
            return componentView;
        }
    }
}
