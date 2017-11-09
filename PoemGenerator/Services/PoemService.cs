using PoemGenerator.BL;
using PoemGenerator.BL.PoemGeneration;
using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.DAL;
using PoemGenerator.Models;
using PoemGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PoemGenerator.Services
{
    // Summary:
    //     Represents the functionality of the application.
    //     Intended to be used by controllers.
    public class PoemService : IPoemService
    {
        IPoemSyntaxRulesParser parser;
        IPoemRepository poemRepository;
        IPoemGen poemGenerator;
        Config config;

        public PoemService(IPoemSyntaxRulesParser parser, IPoemRepository poemRepository, Config config, IPoemGen poemGenerator)
        {
            this.parser = parser;
            this.poemRepository = poemRepository;
            this.config = config;
            this.poemGenerator = poemGenerator;
        }

        // Summary:
        //     Generates the poem schema. Parses the syntax rules from the file
        //     and uses the repository objects to access the database and retrieve
        //     the schema by id.
        //
        // Parameters:
        //   schemaId:
        //     The id by which to find the poem schema.
        // Returns:
        //     The string containing the generated poem.
        public string GeneratePoem(int schemaId)
        {
            IPoemSyntaxRuleDocument doc = parser.Parse(config.SyntaxConfigFile);

            PoemSchema schema = poemRepository.GetSchemaById(schemaId);

            string generatedPoem = poemGenerator.GeneratePoem(schema, doc);

            return generatedPoem;
        }

        // Summary:
        //     Retrieves the all poem schemas using repository object to access the database.
        //
        // Returns:
        //     The list of PoemSchema objects.
        public List<PoemSchema> GetAllPoemSchemas()
        {
            return poemRepository.GetAllSchemas();
        }
    }
}