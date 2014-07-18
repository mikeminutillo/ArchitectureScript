using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class RelationshipSegmentWalker : SegmentWalkerBase<RelationshipSegmentWalker>
    {
        private readonly Relationship _relationship;

        public RelationshipSegmentWalker(Relationship relationship)
        {
            _relationship = relationship;
        }

        [Parse("(.*)")]
        public void AddComment(string comment)
        {
            if (String.IsNullOrWhiteSpace(_relationship.Description))
                _relationship.Description = comment;
            else
                _relationship.Description += Environment.NewLine + comment;
        }
    }
}
