using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.Models
{
    // Summary:
    //     Represents dictionary word.
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Syllables { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
    }
}