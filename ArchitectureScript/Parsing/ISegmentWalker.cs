using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public interface ISegmentWalker
    {
        void Walk(IEnumerable<Segment> segments);
    }
}
