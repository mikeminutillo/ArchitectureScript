using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=true, Inherited= true)]
    public class ParseAttribute : Attribute
    {
        private readonly string _text;
        
        public ParseAttribute(string text)
        {
            _text = text;
        }

        public Regex CreateRegex()
        {
            var text = "^" + _text + "$";
            var options = RegexOptions.Compiled | RegexOptions.IgnoreCase;
            return new Regex(text, options);
        }
    }
}
