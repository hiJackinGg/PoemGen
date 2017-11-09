using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.SyntaxRules
{
    // Summary:
    //     Defines the class with method to parse the rules file.
    //     The file represents the schema of how the different parts 
    //     of speech should follow in poem line.
    public interface IPoemSyntaxRulesParser
    {
        // Summary:
        //     Parses the specified file with syntax rules. As a result
        //     generates a IPoemSyntaxRuleDocument object.
        //
        // Parameters:
        //   fileName:
        //     The name of the file with syntax rules to be parsed.
        // Returns:
        //     IPoemSyntaxRuleDocument instance representing syntax rules.
        IPoemSyntaxRuleDocument Parse(string fileName);
    }
}