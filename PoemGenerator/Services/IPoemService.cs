using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.Services
{
    // Summary:
    //     Defines the functionality of the application.
    //     Intended to be used by controllers.
    public interface IPoemService
    {
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
        string GeneratePoem(int schemaId);

        // Summary:
        //     Retrieves the all poem schemas using repository object to access the database.
        //
        // Returns:
        //     The list of PoemSchema objects.
        List<PoemSchema> GetAllPoemSchemas();
    }
}