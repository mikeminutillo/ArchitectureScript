using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public abstract class View
    {
        private readonly SoftwareSystem _system;
        protected IList<Element> _elements = new List<Element>();
        private readonly IList<int> _exclusions = new List<int>();

        public View(SoftwareSystem system)
        {
            _system = system;
            Description = "";
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public Model Model { get; set; }
        public IEnumerable<ElementView> Elements { get { return _elements.Select(x => new ElementView { Id = x.Id }); } }
        public int SoftwareSystemId { get { return _system.Id; } }
        protected SoftwareSystem System { get { return _system; } }
        


        public IEnumerable<RelationshipView> Relationships
        {
            get
            {
                var elementIds = _elements.Select(x => x.Id).ToArray();
                return from e in _elements
                       from r in e.Relationships
                       where elementIds.Contains(r.SourceId) && elementIds.Contains(r.DestinationId)
                       select new RelationshipView { SourceId = r.SourceId, DestinationId = r.DestinationId };
            }
        }

        public void AddElement(Element element)
        {
            if (!_exclusions.Contains(element.Id))
                _elements.Add(element);
        }


        public virtual void Normalize()
        {
            var reachableIds = Relationships.SelectMany(x => new[] { x.SourceId, x.DestinationId }).ToArray();
            _elements = _elements.Where(x => reachableIds.Contains(x.Id) && !_exclusions.Contains(x.Id)).ToList();
        }

        public bool ShouldSerializeModel()
        {
            return false;
        }

        public void AddExclusion(string tag)
        {
            _exclusions.Add(Model.GetElementByName(tag).Id);
        }

    }
}
