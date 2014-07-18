using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class ElementSegmentWalker<T> : SegmentWalkerBase<T> where T : SegmentWalkerBase<T>
    {
        private readonly Element _element;

        public ElementSegmentWalker (Element element)
	    {
            _element = element;
	    }

        [Parse("uses (.*)")]
        public RelationshipSegmentWalker AddUse(string tag)
        {
            var relationship = _element.AddRelationship(tag, null);
            return new RelationshipSegmentWalker(relationship);
        }

        [Parse("user (.*)")]
        public RelationshipSegmentWalker AddUser(string tag)
        {
            var user = _element.Model.GetElementByName(tag);
            var relationship = user.AddRelationship(_element.Name, null);
            return new RelationshipSegmentWalker(relationship);
        }

        [Parse("desc (.*)")]
        public void SetDescription(string description)
        {
            _element.Description = description;
        }
    }
}
