using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.RandomGenerators
{
    // Summary:
    //     Defines the method to generate a random word among the matched.
    public interface IWordRandomGenerator
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