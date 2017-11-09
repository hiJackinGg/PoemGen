using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.Exceptions
{
    // Summary:
    //     Represents errors that occur during poem generation logic in bussiness layer.
    public class PoemGenerationException : Exception
    {
        public PoemGenerationException()
            : base()
        {
        }

        public PoemGenerationException(String message)
            : base(message)
        {
        }

        public PoemGenerationException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}