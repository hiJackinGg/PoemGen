using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL
{
    // Summary:
    //     Represents the class with method to parse the rules file.
    //     The file represents the schema of how the different parts 
    //     of speech should follow in poem line.
    public class PoemSyntaxRulesParser : IPoemSyntaxRulesParser
    {

        FileReader fileReader;

        public PoemSyntaxRulesParser(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        // Summary:
        //     Parses the specified file with syntax rules. As a result
        //     generates a IPoemSyntaxRuleDocument object.
        //
        // Parameters:
        //   fileName:
        //     The name of the file with syntax rules to be parsed.
        // Returns:
        //     IPoemSyntaxRuleDocument instance representing syntax rules.
        public IPoemSyntaxRuleDocument Parse(string fileName)
        {
            PoemSyntaxRuleDocument doc = new PoemSyntaxRuleDocument();

            string rulesDescriprion = fileReader.ReadTextFromFile(fileName);

            foreach (string line in rulesDescriprion.Split('\n'))
            {
                string[] lineParts = line.Trim().Split(':');

                string node = lineParts[0];
                ISet<string> descendants = new HashSet<string>(lineParts[1].Trim().Split('|'));

                doc.AddRule(node, descendants);
            }

            return doc;
        }
    }
}