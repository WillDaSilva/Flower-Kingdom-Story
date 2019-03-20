/*using System.Collections;
using System.IO;
using UnityEngine;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Samples.Helpers;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Analogue.Loading
{
    public class DialogueLoader
    {

        public ITestOutputHelper output;

        public DialogueLoader(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Main(string s)
        {
            // Setup the input
            var input = new StringReader(s);

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);

            // Examine the stream
            var mapping =
                (YamlMappingNode)yaml.Documents[0].RootNode;

            foreach (var entry in mapping.Children)
            {
                output.WriteLine(((YamlScalarNode)entry.Key).Value);
            }

            // List all the items
            var SetID = (YamlSequenceNode)mapping.Children[new YamlScalarNode("setID")];

            var startNode = (YamlSequenceNode)mapping.Children[new YamlScalarNode("startNode")];

            var entities = (YamlSequenceNode)mapping.Children[new YamlScalarNode("entities")];

            var nodes = (YamlSequenceNode)mapping.Children[new YamlScalarNode("Nodes")];
            foreach (YamlMappingNode node in nodes)
            {
                output.WriteLine(
                    "{0}\t{1}",
                    node.Children[new YamlScalarNode("ID")],
                    node.Children[new YamlScalarNode("summary")],
                    node.Children[new YamlScalarNode("nodeType")],
                    node.Children[new YamlScalarNode("entity")],
                    node.Children[new YamlScalarNode("connections")]
                );
            }
            Debug.Log(output.ToString());
        }
    }
    public class AnalogueLanguageLoader
    {

        private ITestOutputHelper output;

        public AnalogueLanguageLoader(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Main(string s)
        {
            // Setup the input
            var input = new StringReader(s);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var nodeSet = deserializer.Deserialize<Analogue_Set>(input);
            

        }
    }
}*/