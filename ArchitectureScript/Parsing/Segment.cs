using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class Segment
    {
        private readonly IList<Segment> _segments;

        private Segment(string text)
        {
            Text = text;
            _segments = new List<Segment>();
        }

        public string Text { get; private set; }
        public IEnumerable<Segment> SubSegments { get { return _segments.AsEnumerable(); } }

        public void Add(Segment s)
        {
            _segments.Add(s);
        }

        public static IEnumerable<Segment> Parse(string s)
        {
            var segments = new List<Segment>();

            var stack = new Stack<Tuple<int, Segment>>();

            var lines = s.Split('\n');

            foreach (var line in lines)
            {
                var match = Regex.Match(line, @"^(\s*)(.*)$");
                var whiteSpace = match.Result("$1").Replace("\t", "    ");
                var text = match.Result("$2");

                if (String.IsNullOrWhiteSpace(text))
                {
                    stack.Clear();
                    continue;
                }

                var segment = new Segment(text.Trim());

                var indent = whiteSpace.Length;

                if (stack.Any())
                {
                    while (stack.Any() && stack.Peek().Item1 >= indent)
                        stack.Pop();
                    if (stack.Any())
                        stack.Peek().Item2.Add(segment);
                }

                if (stack.Any() == false)
                    segments.Add(segment);
                stack.Push(Tuple.Create(indent, segment));
            }

            return segments;
        }
    }
}
