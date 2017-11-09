using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoemGenerator.Models;
using PoemGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemGenerator.Tests.Utils
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        public void ConvertNounUpperCaseStringToEnumType()
        {
            string noun = "NOUN";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Noun;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(noun, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertVerbUpperCaseStringToEnumType()
        {
            string verb = "VERB";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Verb;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(verb, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertAdjectiveUpperCaseStringToEnumType()
        {
            string adjective = "ADJECTIVE";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Adjective;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(adjective, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertConjuctionUpperCaseStringToEnumType()
        {
            string conjunction = "CONJUNCTION";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Conjunction;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(conjunction, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertPronounUpperCaseStringToEnumType()
        {
            string pronoun = "PRONOUN";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Pronoun;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(pronoun, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertPrepositionUpperCaseStringToEnumType()
        {
            string preposition = "PREPOSITION";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Preposition;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(preposition, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertAdverbUpperCaseStringToEnumType()
        {
            string adverb = "ADVERB";
            bool expectedRes = true;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Adverb;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(adverb, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void ConvertFailedToEnumType()
        {
            string failed = "failed part of speech";
            bool expectedRes = false;
            PartOfSpeech expectedPartOfSpeech = PartOfSpeech.Adjective;
            PartOfSpeech actualPartOfSpeech;

            Converter converter = new Converter();
            bool actualRes = converter.ConvertToEnumType(failed, out actualPartOfSpeech);

            Assert.AreEqual(expectedPartOfSpeech, actualPartOfSpeech);
            Assert.AreEqual(expectedRes, actualRes);
        }
    }
}
