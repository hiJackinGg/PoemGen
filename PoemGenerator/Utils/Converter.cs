using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.Utils
{
    public class Converter
    {
        // Summary:
        //     Converts the part of speech from string type to enum type ignoring the word case.
        //     If it can't be converted to enum, returns false.
        //
        // Parameters:
        //   nodeName:
        //     The string value to be converted to PartOfSpeech enum type.
        //   partOfSpeech:
        //     When this method returns, result contains an object of type PartOfSpeech whose value
        //     is represented by value if the parse operation succeeds. If the parse operation
        //     fails, result contains the '0' (default PartOfSpeech value).
        //     Note that this value need not be a member of the TEnum enumeration. This
        //     parameter is passed uninitialized.
        // Returns:
        //     true if the nodeName parameter matches PartOfSpeech enum type;
        //     otherwise, false.
        public virtual bool ConvertToEnumType(string nodeName, out PartOfSpeech partOfSpeech)
        {
            string nodeName1 = char.ToUpper(nodeName.First()) + nodeName.Substring(1).ToLower();

            if (Enum.TryParse(nodeName1, out partOfSpeech))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}