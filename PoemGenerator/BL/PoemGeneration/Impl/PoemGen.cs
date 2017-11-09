using PoemGenerator.BL.RandomGenerators;
using PoemGenerator.BL.RandomGenerators.Impl;
using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.DAL;
using PoemGenerator.Exceptions;
using PoemGenerator.Models;
using PoemGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.BL.PoemGeneration
{
    // Summary:
    //     Contains the main logic for generation poem text.
    public class PoemGen : IPoemGen
    {
        Config config;
        IDictionaryRepository dictionaryRepository;
        Converter converter;
        IFootRandomGenerator footRandomGenerator;
        INodeRandomGenerator nodeRandomGenerator;
        IWordRandomGenerator wordRandomGenerator;

        public PoemGen(IDictionaryRepository dictionaryRepository,
            Config config, 
            Converter converter, 
            IFootRandomGenerator footRandomGenerator, 
            INodeRandomGenerator nodeRandomGenerator, 
            IWordRandomGenerator wordRandomGenerator)
        {
            this.dictionaryRepository = dictionaryRepository;
            this.config = config;
            this.converter = converter;
            this.footRandomGenerator = footRandomGenerator;
            this.nodeRandomGenerator = nodeRandomGenerator;
            this.wordRandomGenerator = wordRandomGenerator;
        }

        // Summary:
        //     Main method to generate a poem text by the poem schema and syntax rules.
        //
        // Parameters:
        //   schema:
        //     The schema object by which the poem should be constructed.
        //   document:
        //     The object which represents the syntax rules to build a poem.
        // Returns:
        //     The string containing the generated poem text. The line 
        //     breaks separated by '\n' character.
        // Exceptions:
        //   System.ArgumentNullException:
        //     document is null.
        public string GeneratePoem(PoemSchema schema, IPoemSyntaxRuleDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document", "Argument cannot be null.");
            }

            List<string> poemLines = new List<string>();

            foreach (string line in schema.GetLines())
            {
                string generatedLine = this.GeneratePoemLine(line, document);

                poemLines.Add(generatedLine);
            }

            return string.Join("\n", poemLines);
        }

        // Summary:
        //     Generates a poem line by the poem schema and syntax rules.
        //
        // Parameters:
        //   schemaLine:
        //     The schema by which the poem line should be constructed.
        //   document:
        //     The object which represents the syntax rules to build a poem.
        // Returns:
        //     The string containing the generated poem line.
        // Exceptions:
        //   System.ArgumentNullException:
        //     document is null.
        //   PoemGenerationException:
        //     failed to convert string type to PartOfSpeech enum type.
        public virtual string GeneratePoemLine(string schemaLine, IPoemSyntaxRuleDocument doc)
        {
            if (doc == null)
            {
                throw new ArgumentNullException("document", "Argument cannot be null.");
            }

            int maxStep = config.MaxSyllablesCount;

            List<string> poemWords = new List<string>();
            List<string> nodes = doc.GetRootElements();
            string nextNode = String.Empty;

            int i = 0;

            while (i < schemaLine.Length)
            {
                string foot = String.Empty;
                int footSize = default(int);

                List<Word> matchedWords = new List<Word>();
                
                do
                {
                    footSize = footRandomGenerator.Generate(1, maxStep + 1);

                    if (i + footSize >= schemaLine.Length)
                    {
                        foot = schemaLine.Substring(i);

                        //in case the last word in the line, retrive only the elements contaning END node
                        List<string> nodes1 = nodes.Intersect(doc.GetAllEndElements()).ToList();
                        nextNode = nodes1[nodeRandomGenerator.Generate(0, nodes1.Count())];
                    }
                    else
                    {
                        foot = schemaLine.Substring(i, footSize);
                        nextNode = nodes[nodeRandomGenerator.Generate(0, nodes.Count())];
                    }

                    //in case one syllable it can be both stressed and unstressed
                    if (foot.Length == 1)
                    {
                        foot = "x,-";
                    }

                    PartOfSpeech partOfSpeech;

                    if (converter.ConvertToEnumType(nextNode, out partOfSpeech))
                    {
                        matchedWords = dictionaryRepository.GetWords(foot, partOfSpeech);
                    }
                    else
                    {
                        throw new PoemGenerationException("Unable to convert the part of speech from string type to enum type. String: " + nextNode);
                    }
                }
                while (matchedWords.Count() == 0);

                string w = matchedWords[wordRandomGenerator.Generate(0, matchedWords.Count())].Value;
                poemWords.Add(w);

                i += footSize;
                nodes = doc.GetNextElements(nextNode);
            }

            return string.Join(" ", poemWords);
        }
    }
}