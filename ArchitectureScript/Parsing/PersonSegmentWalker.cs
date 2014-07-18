using ArchitectureScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript.Parsing
{
    public class PersonSegmentWalker : ElementSegmentWalker<PersonSegmentWalker>
    {
        public PersonSegmentWalker(Person person) : base(person)
        {

        }
    }
}
