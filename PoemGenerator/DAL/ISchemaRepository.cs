using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.DAL
{
    // Summary:
    //     Defines the methods to access to syllable schemas.
    public interface ISchemaRepository
    {
        // Summary:
        //     Retrieves the schema by id.
        //
        // Parameters:
        //   id:
        //     The schema id to retrieve by.
        // Returns:
        //     PoemSchema object.
        PoemSchema GetSchemaById(int id);

        // Summary:
        //     Retrieves all schemas.
        //
        // Returns:
        //     List of PoemSchema objects.
        List<PoemSchema> GetAllSchemas();
    }
}