using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.PoemGeneration
{
    public interface IPoemGen
    {
        string GeneratePoem(PoemSchema schema, IPoemSyntaxRuleDocument document);
        string GeneratePoemLine(string schemaLine, IPoemSyntaxRuleDocument document);
    }
}