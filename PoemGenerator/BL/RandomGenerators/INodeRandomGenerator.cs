using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.RandomGenerators
{
    // Summary:
    //     Define the method to generate the next part of speech node in the syntax rules.
    public interface INodeRandomGenerator
    {
        // Summary:
        //     Generates a random integer value in the specified interval.
        //
        // Parameters:
        //   minValue:
        //     Minimun value of the interval.
        //   maxValue:
        //     Maximum value of the interval.
        // Returns:
        //     Random integer value.
        int Generate(int minValue, int maxValue);
    }
}