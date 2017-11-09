using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoemGenerator.BL;
using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.Models;
using PoemGenerator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemGenerator.Tests.SyntaxRules
{

    [TestClass]
    public class PoemSyntaxRulesParserTest
    {

        [TestMethod]
        public void ParseTestRulesSuccessTest()
        {
            //Arrange
            string testFile = "rule.txt";
            string testRules =
                    "LINE: NOUN|PREPOSITION|PRONOUN\n" +
                    "ADJECTIVE: NOUN|ADJECTIVE|$END\n" +
                    "NOUN: VERB|PREPOSITION|$END\n" +
                    "PRONOUN: NOUN|ADJECTIVE\n" +
                    "VERB: PREPOSITION|PRONOUN|$END\n" +
                    "PREPOSITION: NOUN|PRONOUN|ADJECTIVE|$END\n" +
                    "CONJUCTION: NOUN";

            Dictionary<string, ISet<string>> rules = new Dictionary<string, ISet<string>>();

            rules["LINE"] = new HashSet<string>()
            {
                "NOUN",
                "PREPOSITION",
                "PRONOUN"
            };

            rules["ADJECTIVE"] = new HashSet<string>()
            {
                "NOUN",
                "ADJECTIVE",
                "$END"
            };

            rules["NOUN"] = new HashSet<string>()
            {
                "VERB",
                "PREPOSITION",
                "$END"
            };

            rules["PRONOUN"] = new HashSet<string>()
            {
                "NOUN",
                "ADJECTIVE"
            };

            rules["VERB"] = new HashSet<string>()
            {
                "PREPOSITION",
                "PRONOUN",
                "$END"
           };

            rules["PREPOSITION"] = new HashSet<string>()
            {
                "NOUN",
                "PRONOUN",
                "ADJECTIVE",
                "$END"
           };

            rules["CONJUCTION"] = new HashSet<string>()
            {
                "NOUN",
            };

            PoemSyntaxRuleDocument expectedDocument = new PoemSyntaxRuleDocument();
            expectedDocument.Rules = rules;

            Mock<FileReader> mockFileReader = new Mock<FileReader>();
            mockFileReader.Setup(m => m.ReadTextFromFile(testFile)).Returns(testRules);

            IPoemSyntaxRulesParser parser = new PoemSyntaxRulesParser(mockFileReader.Object);

            //Act
            IPoemSyntaxRuleDocument actualDocument = parser.Parse(testFile);

            //Assert
            Assert.AreEqual(expectedDocument, actualDocument);

        }
    }
}
