using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoemGenerator.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemGenerator.Tests.BL.SyntaxRules
{
    [TestClass]
    public class PoemSyntaxRulesDocumentTest
    {
        [TestMethod]
        public void GetNextElementsTest()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules = new Dictionary<string, ISet<string>>();
            string parenElement = "NOUN";
            ISet<string> expectedDescendantsElems = new HashSet<string>() { "VERB", "CONJUCTION" };
            rules[parenElement] = expectedDescendantsElems;

            PoemSyntaxRuleDocument document = new PoemSyntaxRuleDocument();
            document.Rules = rules;

            //Act
            List<string> actualElems = document.GetNextElements(parenElement);

            //Assert
            CollectionAssert.AreEqual(expectedDescendantsElems.ToList(), actualElems);
        }

        [TestMethod]
        public void GetRootElementsTest()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules = new Dictionary<string, ISet<string>>();
            string rootElement = PoemSyntaxRuleDocument.RootName;
            ISet<string> expectedDescendantsElems = new HashSet<string>() { "NOUN", "VERB" };
            rules[rootElement] = expectedDescendantsElems;

            PoemSyntaxRuleDocument document = new PoemSyntaxRuleDocument();
            document.Rules = rules;

            //Act
            List<string> actualElems = document.GetRootElements();

            //Assert
            CollectionAssert.AreEqual(expectedDescendantsElems.ToList(), actualElems);
        }

        [TestMethod]
        public void GetAllEndElementsTest()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules = new Dictionary<string, ISet<string>>();
            rules["NOUN"] = new HashSet<string>() { "VERB", PoemSyntaxRuleDocument.EndNode };
            rules["ADJECTIVE"] = new HashSet<string>() { "VERB", "NOUN" };
            rules["VERB"] = new HashSet<string>() { "NOUN", PoemSyntaxRuleDocument.EndNode };

            List<string> expectedElems = new List<string>() { "NOUN", "VERB" };

            PoemSyntaxRuleDocument document = new PoemSyntaxRuleDocument();
            document.Rules = rules;

            //Act
            List<string> actualElems = document.GetAllEndElements();

            //Assert
            CollectionAssert.AreEqual(expectedElems.ToList(), actualElems);
        }

        [TestMethod]
        public void AddRuleTest()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules = new Dictionary<string, ISet<string>>();
            string parenElement = "NOUN";
            ISet<string> expectedElements = new HashSet<string>() { "VERB", "CONJUCTION" };
            rules[parenElement] = expectedElements;

            PoemSyntaxRuleDocument document = new PoemSyntaxRuleDocument();

            //Act
            document.AddRule(parenElement, expectedElements);

            //Assert
            List<string> actualElements = document.Rules[parenElement].ToList();
            CollectionAssert.AreEqual(expectedElements.ToList(), actualElements);
        }

        [TestMethod]
        public void OverridenEqualsMethodTest()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules1 = new Dictionary<string, ISet<string>>();
            Dictionary<string, ISet<string>> rules2 = new Dictionary<string, ISet<string>>();
            rules1["NOUN"] = new HashSet<string>() { "VERB" };
            rules2["NOUN"] = new HashSet<string>() { "VERB" };
            PoemSyntaxRuleDocument doc1 = new PoemSyntaxRuleDocument();
            PoemSyntaxRuleDocument doc2 = new PoemSyntaxRuleDocument();
            doc1.Rules = rules1;
            doc2.Rules = rules2;

            //Act
            bool result = doc1.Equals(doc2);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OverridenEqualsMethodSeqTest()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules1 = new Dictionary<string, ISet<string>>();
            rules1["LINE"] = new HashSet<string>()
            {
                "NOUN",
                "PREPOSITION",
                "PRONOUN"
            };

            rules1["ADJECTIVE"] = new HashSet<string>()
            {
                "NOUN",
                "ADJECTIVE",
                "$END"
            };

            rules1["NOUN"] = new HashSet<string>()
            {
                "VERB",
                "PREPOSITION",
                "$END"
            };

            rules1["PRONOUN"] = new HashSet<string>()
            {
                "NOUN",
                "ADJECTIVE"
            };

            rules1["VERB"] = new HashSet<string>()
            {
                "PREPOSITION",
                "PRONOUN",
                "$END"
           };

            rules1["PREPOSITION"] = new HashSet<string>()
            {
                "NOUN",
                "PRONOUN",
                "ADJECTIVE",
                "$END"
           };

            rules1["CONJUCTION"] = new HashSet<string>()
            {
                "NOUN",
            };

            Dictionary<string, ISet<string>> rules2 = new Dictionary<string, ISet<string>>(rules1);


            PoemSyntaxRuleDocument doc1 = new PoemSyntaxRuleDocument();
            PoemSyntaxRuleDocument doc2 = new PoemSyntaxRuleDocument();
            doc1.Rules = rules1;
            doc2.Rules = rules2;

            //Act
            bool result = doc1.Equals(doc2);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OverridenEqualsMethodDiffSize1Test()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules1 = new Dictionary<string, ISet<string>>();
            Dictionary<string, ISet<string>> rules2 = new Dictionary<string, ISet<string>>();
            rules1["NOUN"] = new HashSet<string>() { "VERB" };
            rules1["VERB"] = new HashSet<string>() { "NOUN" };
            rules2["NOUN"] = new HashSet<string>() { "VERB" };
            PoemSyntaxRuleDocument doc1 = new PoemSyntaxRuleDocument();
            PoemSyntaxRuleDocument doc2 = new PoemSyntaxRuleDocument();
            doc1.Rules = rules1;
            doc2.Rules = rules2;

            //Act
            bool result = doc1.Equals(doc2);

            //Assert
            Assert.IsFalse(result);
        }

                [TestMethod]
        public void OverridenEqualsMethodDiffSize2Test()
        {
            //Arrange
            Dictionary<string, ISet<string>> rules1 = new Dictionary<string, ISet<string>>();
            Dictionary<string, ISet<string>> rules2 = new Dictionary<string, ISet<string>>();
            rules1["NOUN"] = new HashSet<string>() { "VERB", "ADJECTIVE" };
            rules2["NOUN"] = new HashSet<string>() { "VERB" };
            PoemSyntaxRuleDocument doc1 = new PoemSyntaxRuleDocument();
            PoemSyntaxRuleDocument doc2 = new PoemSyntaxRuleDocument();
            doc1.Rules = rules1;
            doc2.Rules = rules2;

            //Act
            bool result = doc1.Equals(doc2);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
