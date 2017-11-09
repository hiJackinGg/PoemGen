using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoemGenerator.BL;
using PoemGenerator.DAL;
using PoemGenerator.Models;
using PoemGenerator.Utils;
using PoemGenerator.Services;
using PoemGenerator.BL.RandomGenerators;
using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.BL.PoemGeneration;
using PoemGenerator.BL.RandomGenerators.Impl;
using PoemGenerator.Exceptions;

namespace PoemGenerator.Tests.BL
{
    [TestClass]
    public class GeneratePoemTest
    {
        private Mock<IDictionaryRepository> dictionaryRepository = new Mock<IDictionaryRepository>();
        private Mock<IPoemSyntaxRuleDocument> document = new Mock<IPoemSyntaxRuleDocument>();
        private Mock<Config> config = new Mock<Config>();
        private Mock<Converter> converter = new Mock<Converter>();
        private Mock<IFootRandomGenerator> footRandomGenerator = new Mock<IFootRandomGenerator>();
        private Mock<IWordRandomGenerator> wordRandomGenerator = new Mock<IWordRandomGenerator>();
        private Mock<INodeRandomGenerator> nodeRandomGenerator = new Mock<INodeRandomGenerator>();

        [TestInitialize]
        public void Init()
        {
            InitTestData();
        }

        [TestMethod]
        public void GeneratePoemLineOneSyllableTest()
        {
            //Arrange
            string expectedLine = "oneSyllableNoun oneSyllableVerb oneSyllableNoun oneSyllableVerb oneSyllableNoun";
            PoemGen poemGenerator = new PoemGen(
                dictionaryRepository.Object, 
                config.Object, 
                converter.Object, 
                footRandomGenerator.Object,
                nodeRandomGenerator.Object, 
                wordRandomGenerator.Object);
            
            //Act
            string actualLine = poemGenerator.GeneratePoemLine("x-x-x", document.Object);

            //Assert
            Assert.AreEqual(expectedLine, actualLine);

            dictionaryRepository.Verify(mock => mock.GetWords("x,-", PartOfSpeech.Noun), Times.Exactly(3));
            dictionaryRepository.Verify(mock => mock.GetWords("x,-", PartOfSpeech.Verb), Times.Exactly(2));
            footRandomGenerator.Verify(mock => mock.Generate(1, 2), Times.Exactly(5));
            wordRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(5));
            nodeRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(5));
            config.Verify(mock => mock.MaxSyllablesCount, Times.AtLeast(1));
        }

        [TestMethod]
        public void GeneratePoemLineBreakTest()
        {
            //Arrage
            config.Setup(m => m.MaxSyllablesCount).Returns(3);
            footRandomGenerator.Setup(m => m.Generate(1, 4)).Returns(3);

            string expectedLine = "x-xNoun -xVerb";
            PoemGen poemGenerator = new PoemGen(
                dictionaryRepository.Object, 
                config.Object, 
                converter.Object, 
                footRandomGenerator.Object,
                nodeRandomGenerator.Object,
                wordRandomGenerator.Object);
            
            //Act
            string actualLine = poemGenerator.GeneratePoemLine("x-x-x", document.Object);

            //Assert
            Assert.AreEqual(expectedLine, actualLine);

            dictionaryRepository.Verify(mock => mock.GetWords("x-x", PartOfSpeech.Noun), Times.Exactly(1));
            dictionaryRepository.Verify(mock => mock.GetWords("-x", PartOfSpeech.Verb), Times.Exactly(1));
            footRandomGenerator.Verify(mock => mock.Generate(1, 4), Times.Exactly(2));
            wordRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(2));
            nodeRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(2));
            config.Verify(mock => mock.MaxSyllablesCount, Times.AtLeast(1));
        }

        [ExpectedException(typeof(PoemGenerationException))]
        [TestMethod]
        public void GeneratePoemLineInvalidTypeTest()
        {
            //Arrange
            document.Setup(d => d.GetNextElements(PartOfSpeech.Noun.ToString())).Returns(new List<string>() { "InvalidEnumTypeWord" });

            PoemGen poemGenerator = new PoemGen(
                dictionaryRepository.Object,
                config.Object, 
                converter.Object, 
                footRandomGenerator.Object, 
                nodeRandomGenerator.Object, 
                wordRandomGenerator.Object);
            
            //Act
            poemGenerator.GeneratePoemLine("x-x-x", document.Object);

            //Assert
            dictionaryRepository.Verify(mock => mock.GetWords("x,-", PartOfSpeech.Noun), Times.Exactly(1));
            dictionaryRepository.Verify(mock => mock.GetWords("x,-", PartOfSpeech.Verb), Times.Never);
            footRandomGenerator.Verify(mock => mock.Generate(1, 2), Times.Exactly(1));
            wordRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Never);
            nodeRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(1));
            config.Verify(mock => mock.MaxSyllablesCount, Times.AtLeast(1));
        }

        [TestMethod]
        public void GeneratePoemLineEmptySchemaTest()
        {
            //Arrange
            string expectedLine = String.Empty;

            //Act
            PoemGen poemGenerator = new PoemGen(
                dictionaryRepository.Object,
                config.Object,
                converter.Object,
                footRandomGenerator.Object, 
                nodeRandomGenerator.Object,
                wordRandomGenerator.Object);
            string actualLine = poemGenerator.GeneratePoemLine("", document.Object);

            //Assert
            Assert.AreEqual(expectedLine, actualLine);

            config.Verify(mock => mock.MaxSyllablesCount, Times.Exactly(1));
            dictionaryRepository.Verify(mock => mock.GetWords(It.IsAny<string>(), It.IsAny<PartOfSpeech>()), Times.Never);
            dictionaryRepository.Verify(mock => mock.GetWords(It.IsAny<string>(), It.IsAny<PartOfSpeech>()), Times.Never);
            footRandomGenerator.Verify(mock => mock.Generate(1, 2), Times.Never);
            wordRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Never);
            nodeRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Never);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GeneratePoemLineArgumentNullTest()
        {
            //Arrange
            string expectedLine = String.Empty;

            PoemGen poemGenerator = new PoemGen(
                dictionaryRepository.Object,
                config.Object,
                converter.Object,
                footRandomGenerator.Object,
                nodeRandomGenerator.Object,
                wordRandomGenerator.Object);
           
            //Act
            string actualLine = poemGenerator.GeneratePoemLine("", null);

            //Assert
            Assert.AreEqual(expectedLine, actualLine);

            config.Verify(mock => mock.MaxSyllablesCount, Times.Never);
            dictionaryRepository.Verify(mock => mock.GetWords(It.IsAny<string>(), It.IsAny<PartOfSpeech>()), Times.Never);
            dictionaryRepository.Verify(mock => mock.GetWords(It.IsAny<string>(), It.IsAny<PartOfSpeech>()), Times.Never);
            footRandomGenerator.Verify(mock => mock.Generate(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
            wordRandomGenerator.Verify(mock => mock.Generate(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
            nodeRandomGenerator.Verify(mock => mock.Generate(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void GeneratePoemLineIntersectWithEndNodesTest()
        {
            //Arrange
            document.Setup(d => d.GetRootElements()).Returns(new List<string>() { PartOfSpeech.Noun.ToString(), PartOfSpeech.Adjective.ToString() });
            document.Setup(d => d.GetAllEndElements()).Returns(new List<string>() { PartOfSpeech.Noun.ToString() });

            string expectedLine = "oneSyllableNoun";
            PoemGen poemGenerator = new PoemGen(
                dictionaryRepository.Object, 
                config.Object,
                converter.Object,
                footRandomGenerator.Object,
                nodeRandomGenerator.Object,
                wordRandomGenerator.Object);

            //Act
            string actualLine = poemGenerator.GeneratePoemLine("x", document.Object);

            //Assert
            Assert.AreEqual(expectedLine, actualLine);

            dictionaryRepository.Verify(mock => mock.GetWords("x,-", PartOfSpeech.Noun), Times.Exactly(1));
            dictionaryRepository.Verify(mock => mock.GetWords("x,-", PartOfSpeech.Verb), Times.Never);
            footRandomGenerator.Verify(mock => mock.Generate(1, 2), Times.Exactly(1));
            wordRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(1));
            nodeRandomGenerator.Verify(mock => mock.Generate(0, 1), Times.Exactly(1));
            config.Verify(mock => mock.MaxSyllablesCount, Times.AtLeast(1));
        }

        [TestMethod]
        public void GeneratePoemMethodTest()
        {
            //Arrange
            Mock<IPoemSyntaxRuleDocument> documentMock = new Mock<IPoemSyntaxRuleDocument>();
            Mock<PoemSchema> poemSchemaMock = new Mock<PoemSchema>();
            const int linesCount = 2;
            poemSchemaMock.Setup(m => m.GetLines()).Returns(new string[linesCount] { "line1", "line2" });

            PoemGen prtialMock = new PoemGenMock(
                dictionaryRepository.Object,
                config.Object, 
                converter.Object, 
                footRandomGenerator.Object,
                nodeRandomGenerator.Object,
                wordRandomGenerator.Object);
            string expectedLine = "word1 word2 word3\nword1 word2 word3";

            //Act
            string actualLine = prtialMock.GeneratePoem(poemSchemaMock.Object, documentMock.Object);

            //Assert
            Assert.AreEqual(expectedLine, actualLine);
        }



        private void InitTestData()
        {
            MockConfig();
            MockConverter();
            MockRandomGenerators();
            MockIPoemSyntaxRuleDocument();
            MockIDictionaryRepository();
        }

        private void MockIPoemSyntaxRuleDocument()
        {
            document.Setup(d => d.GetNextElements(PartOfSpeech.Noun.ToString())).Returns(new List<string>() { PartOfSpeech.Verb.ToString() });
            document.Setup(d => d.GetNextElements(PartOfSpeech.Verb.ToString())).Returns(new List<string>() { PartOfSpeech.Noun.ToString() });
            document.Setup(d => d.GetRootElements()).Returns(new List<string>() { PartOfSpeech.Noun.ToString() });
            document.Setup(d => d.GetAllEndElements()).Returns(new List<string>() { PartOfSpeech.Noun.ToString(), PartOfSpeech.Verb.ToString() });
        }
        private void MockConfig()
        {
            config.Setup(m => m.MaxSyllablesCount).Returns(1);
        }
        private void MockConverter()
        {
            PartOfSpeech partOfSpeech1 = PartOfSpeech.Noun;
            PartOfSpeech partOfSpeech2 = PartOfSpeech.Verb;
            converter.Setup(m => m.ConvertToEnumType("Noun", out partOfSpeech1)).Returns(true);
            converter.Setup(m => m.ConvertToEnumType("Verb", out partOfSpeech2)).Returns(true);
        }
        private void MockRandomGenerators()
        {
            footRandomGenerator.Setup(m => m.Generate(1, 2)).Returns(1);
            wordRandomGenerator.Setup(m => m.Generate(0, 1)).Returns(0);
            nodeRandomGenerator.Setup(m => m.Generate(0, 1)).Returns(0);
        }

        private void MockIDictionaryRepository()
        {
            dictionaryRepository.Setup(d => d.GetWords("x,-", PartOfSpeech.Noun)).Returns<string, PartOfSpeech>((syllablesSchema, type) =>
            {
                List<Word> words = new List<Word>() { new Word() { Value = "oneSyllableNoun", Syllables = syllablesSchema, PartOfSpeech = PartOfSpeech.Noun } };

                return words;
            });

            dictionaryRepository.Setup(d => d.GetWords("x,-", PartOfSpeech.Verb)).Returns<string, PartOfSpeech>((syllablesSchema, type) =>
            {
                List<Word> words = new List<Word>() { new Word() { Value = "oneSyllableVerb", Syllables = syllablesSchema, PartOfSpeech = PartOfSpeech.Verb } };

                return words;
            });

            dictionaryRepository.Setup(d => d.GetWords("x-x", PartOfSpeech.Noun)).Returns<string, PartOfSpeech>((syllablesSchema, type) =>
            {
                List<Word> words = new List<Word>() { new Word() { Value = "x-xNoun", Syllables = syllablesSchema, PartOfSpeech = PartOfSpeech.Noun } };

                return words;
            });

            dictionaryRepository.Setup(d => d.GetWords("-x", PartOfSpeech.Verb)).Returns<string, PartOfSpeech>((syllablesSchema, type) =>
            {
                List<Word> words = new List<Word>() { new Word() { Value = "-xVerb", Syllables = syllablesSchema, PartOfSpeech = PartOfSpeech.Verb } };

                return words;
            });
        }

        // Class inherited from PoemGen to mock GeneratePoemLine() method and test GeneratePoem() method which uses GeneratePoemLine()
        class PoemGenMock : PoemGen
        {
            public PoemGenMock(IDictionaryRepository dictionaryRepository,
            Config config, 
            Converter converter, 
            IFootRandomGenerator footRandomGenerator, 
            INodeRandomGenerator nodeRandomGenerator, 
            IWordRandomGenerator wordRandomGenerator)
                : base(dictionaryRepository, config, converter, footRandomGenerator, nodeRandomGenerator, wordRandomGenerator)
            { }
                
            public override string GeneratePoemLine(string schemaLine, IPoemSyntaxRuleDocument document)
            {
                return "word1 word2 word3";
            }
        }

    }
}
