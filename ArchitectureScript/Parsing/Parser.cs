using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class Parser
    {
        public Model.Model CreateModel(string script)
        {
            var model = new Model.Model();
            UpdateModel(model, script);
            return model;
        }

        public void UpdateModel(Model.Model model, string script)
        {
            var segments = Segment.Parse(script);
            var walker = new ModelSegmentWalker(model) as ISegmentWalker;
            walker.Walk(segments);
        }
    }
}
