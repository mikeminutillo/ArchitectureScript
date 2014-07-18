using ArchitectureScript.Parsing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureScript
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();
            var model = new Model.Model();

            foreach(var file in args)
            {
                var text = File.ReadAllText(file);
                parser.UpdateModel(model, text);
            }

            model.Normalise();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(model);

            Console.WriteLine(json);
        }
    }
}
