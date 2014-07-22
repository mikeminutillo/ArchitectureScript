using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class ViewSegmentWalker : SegmentWalkerBase<ViewSegmentWalker>
    {
        private readonly View _view;

        public ViewSegmentWalker(View view)
        {
            _view = view;
        }

        [Parse("exclude (.*)")]
        public void AddExclusion(string tag)
        {
            _view.AddExclusion(tag);
        }
    }
}
