using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public abstract class Element
    {
        public Model Model { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        private readonly IList<Relationship> _relationships = new List<Relationship>();

        public Relationship AddRelationship(string destination, string description)
        {
            var relationship = new Relationship();
            relationship.Source = this;
            relationship.DestinationTag = destination;
            relationship.Description = description;
            _relationships.Add(relationship);
            return relationship;
        }

        public void Normalise()
        {
            foreach (var relationship in _relationships)
            {
                relationship.Destination = Model.GetElementByName(relationship.DestinationTag);
            }
        }

        public IEnumerable<Relationship> Relationships
        {
            get { return _relationships; }
        }

        public bool ShouldSerializeModel()
        {
            return false;
        }
    }
}
