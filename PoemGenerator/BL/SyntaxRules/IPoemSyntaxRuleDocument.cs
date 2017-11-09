using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.SyntaxRules
{
    // Summary:
    //     Defines the document describing the syntax rules.
    //     Syntax rules represent the words sequence in poem line.
    public interface IPoemSyntaxRuleDocument
    {
        // Summary:
        //     Retrieves the elements which can be first in the stored words sequence. 
        //
        // Returns:
        //     The list of first possible elements in the word sequence.
        List<string> GetRootElements();

        // Summary:
        //     Retrieves the descendants elements of the specified element. 
        //
        // Parameters:
        //   element:
        //     The node which descendants should be retrieved.
        // Returns:
        //     The list of elements followed by specified element.
        List<string> GetNextElements(string element);

        // Summary:
        //     Retrieves all end elements from the stored words sequence. 
        //     The end element is that contains the node with '$END' name among descendants nodes.
        //
        // Returns:
        //     The list of end elements.
        List<string> GetAllEndElements();
    }
}