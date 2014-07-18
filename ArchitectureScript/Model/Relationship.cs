using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Model
{
    public class Relationship
    {
        public Element Source { get; set; }
        public Element Destination { get; set; }
        public string Description { get; set; }
        public string DestinationTag { get; set; }

        public bool ShouldSerializeSource() { return false; }
        public bool ShouldSerializeDestination() { return false; }
        public bool ShouldSerializeDestinationTag() { return false; }

        public int SourceId { get { return Source.Id; } }
        public int DestinationId { get { return Destination.Id; } }
    }
}
