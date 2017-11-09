using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PoemGenerator.DAL
{
    // Summary:
    //     Object to access the database. Implements all the data access functionality for the application.
    public class PoemRepository : IPoemRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Summary:
        //     Retrieves the schema by id.
        //
        // Parameters:
        //   id:
        //     The schema id to retrieve by.
        // Returns:
        //     PoemSchema object.
        public PoemSchema GetSchemaById(int id)
        {
            string query = "select value from [Schema] where id = @id";
            string schema = String.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", id));
                    schema = command.ExecuteScalar() as string;
                }
            }

            return new PoemSchema { Value = schema, Id = id };
        }

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
        public List<Word> GetWords(string syllablesSchema, PartOfSpeech type)
        {
            string query = "select id, word, syllables, type from Dictionary where syllables = @syllablesSchema and type = @type";
            List<Word> matchedWords = new List<Word>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@syllablesSchema", syllablesSchema));
                    command.Parameters.Add(new SqlParameter("@type", type.ToString()));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string word = reader.GetString(1);
                        string syllables = reader.GetString(2);
                        string type1 = reader.GetString(3);

                        PartOfSpeech partOfSpeech;
                        if (Enum.TryParse(type1, out partOfSpeech))
                        {
                            matchedWords.Add(new Word { Id = id, Value = word, Syllables = syllables, PartOfSpeech = partOfSpeech });
                        }
                    }
                }
            }

            return matchedWords;
        }

        // Summary:
        //     Retrieves all schemas.
        //
        // Returns:
        //     List of PoemSchema objects.
        public List<PoemSchema> GetAllSchemas()
        {
            string query = "select id, value from [Schema]";
            List<PoemSchema> schemas = new List<PoemSchema>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string value = reader.GetString(1);

                        schemas.Add(new PoemSchema { Id = id, Value = value});
                    }
                }
            }

            return schemas;
        }
    }
}