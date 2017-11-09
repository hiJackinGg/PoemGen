using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.DAL
{
    // Summary:
    //     Defines the methods to access the Dictionary of words.
    public interface IDictionaryRepository
    {
        // Summary:
        //     Retrieves words from dictionary by word syllables schema and part of speech type.
        //
        // Parameters:
        //   syllablesSchema:
        //     The syllables schema of the word to be retrieved.
        //   type:
        //     PartOfSpeech object representing the type of word.
        // Returns:
        //     The list of Word objects.
        List<Word> GetWords(string syllablesSchema, PartOfSpeech type);
    }
}