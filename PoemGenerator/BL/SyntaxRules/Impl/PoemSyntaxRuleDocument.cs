using PoemGenerator.BL.SyntaxRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL
{
    // Summary:
    //     Represents the document describing the syntax rules.
    //     Syntax rules represent the words sequence in poem line.
    public class PoemSyntaxRuleDocument : IPoemSyntaxRuleDocument
    {
        // Summary:
        //     Collection to store the rules.
        private Dictionary<string, ISet<string>> rules = new Dictionary<string, ISet<string>>();

        // Summary:
        //     Represents the root element in the word sequence. This field is read-only.
        public static readonly string RootName = "LINE";

        // Summary:
        //     Represents the end element in the word sequence. This field is read-only.
        public static readonly string EndNode = "$END";

        // Summary:
        //     Add a new rule to the document. 
        //
        // Parameters:
        //   element:
        //     The node name to be added in the words sequence.
        //   nextElements:
        //     The following set of nodes.
        public virtual void AddRule(string element, ISet<string> nextElements)
        {
            if (rules.ContainsKey(element))
            {
                rules[element].UnionWith(nextElements);
            }
            else
            {
                rules[element] = nextElements;
            }
        }

        // Summary:
        //     Retrieves the descendants elements of the specified element. 
        //
        // Parameters:
        //   element:
        //     The node which descendants should be retrieved.
        // Returns:
        //     The list of elements followed by specified element.
        public List<string> GetNextElements(string element)
        {
            return rules[element].Where(nodes => !nodes.Contains(EndNode)).ToList();
        }

        // Summary:
        //     Retrieves all end elements from the stored words sequence. 
        //     The end element is that contains the node with '$END' name among descendants nodes.
        //
        // Returns:
        //     The list of end elements.
        public List<string> GetAllEndElements()
        {
            return rules.Where(e => e.Value.Contains(EndNode)).Select(e1 => e1.Key).ToList();
        }

        // Summary:
        //     Retrieves the elements which can be first in the stored words sequence. 
        //
        // Returns:
        //     The list of first possible elements in the word sequence.
        public List<string> GetRootElements()
        {
            return rules[RootName].ToList();
        }

        public Dictionary<string, ISet<string>> Rules
        {
            get { return rules; }
            set { rules = value; }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PoemSyntaxRuleDocument p = (PoemSyntaxRuleDocument)obj;

            if (rules.Count != p.rules.Count)
                return false;
            if (rules.Keys.Except(p.rules.Keys).Any())
                return false;
            if (p.rules.Keys.Except(rules.Keys).Any())
                return false;
            foreach (var pair in rules)
                if (!(pair.Value).SetEquals(p.rules[pair.Key]))
                    return false;
            return true;
        }

        public override string ToString()
        {
            return string.Join("\n ", rules.Select(kvp => string.Join(":", kvp.Key, string.Join(",", kvp.Value))));
        }

    }
}