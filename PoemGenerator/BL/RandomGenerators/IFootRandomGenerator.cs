using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.RandomGenerators
{
    // Summary:
    //     Defines the method to generate the syllables schema size corresponding the word in the dictionary.
    public interface IFootRandomGenerator
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