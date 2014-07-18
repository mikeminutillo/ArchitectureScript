using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public abstract class SegmentWalkerBase<T> : ISegmentWalker where T : SegmentWalkerBase<T>
    {
        private static readonly IEnumerable<Tuple<Regex, MethodInfo>> _parsers;

        static SegmentWalkerBase ()
        {
            _parsers = (from method in typeof(T).GetMethods()
                        from parse in method.GetCustomAttributes(typeof(ParseAttribute), true).OfType<ParseAttribute>()
                        select Tuple.Create(parse.CreateRegex(), method)).ToList();

        }

        void ISegmentWalker.Walk(IEnumerable<Segment> segments)
        {
            foreach(var segment in segments)
            {
                var executionContext = (from p in _parsers
                                        let match = p.Item1.Match(segment.Text)
                                        where match.Success
                                        select new { match, method = p.Item2 }).FirstOrDefault();


                if (executionContext != null)
                {
                    var parameters = executionContext.method.GetParameters().Select((p, i) => executionContext.match.Groups[i + 1].Value).Cast<object>().ToArray();
                    var subwalker = executionContext.method.Invoke(this, parameters) as ISegmentWalker;
                    if (subwalker != null)
                    {
                        subwalker.Walk(segment.SubSegments);
                    }
                }
            }
        }
    }
}
