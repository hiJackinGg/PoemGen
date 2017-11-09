using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PoemGenerator.Models
{
    // Summary:
    //     Represents poem schema.
    public class PoemSchema
    {
        public int Id { get; set; }
        public string Value { get; set; }

        // Summary:
        //     Split the poem text into lines separated by "\\n", "\n" separators.
        //
        // Returns:
        //     Array of splitted poem lines.
        public virtual string[] GetLines()
        {
            return Value.Split(new string[] { "\\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}