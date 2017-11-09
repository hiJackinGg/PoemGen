using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoemGenerator.BL;
using PoemGenerator.BL.PoemGeneration;
using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.DAL;
using PoemGenerator.Models;
using PoemGenerator.Services;
using PoemGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemGenerator.Tests.Services
{
    [TestClass]
    public class PoemServiceTest
    {
        private Mock<IPoemRepository> mockPoemRepository = new Mock<IPoemRepository>();
        private Mock<IPoemSyntaxRulesParser> mockParser = new Mock<IPoemSyntaxRulesParser>();
        private Mock<Config> mockConfig = new Mock<Config>();
        private Mock<IPoemGen> mockPoemGenerator = new Mock<IPoemGen>();

        [TestMethod]
        public void ServiceGeneratePoemSuccessTest()
        {
            //Arrange
            int testSchemaId = 1;
            string expectedPoemText = "poem";
            Mock<PoemSchema> mockPoemSchema = new Mock<PoemSchema>();
            mockPoemRepository.Setup(m => m.GetSchemaById(testSchemaId)).Returns(mockPoemSchema.Object);

            string testFilePath = "rules.csv";
            mockConfig.Setup(m => m.SyntaxConfigFile).Returns(testFilePath);

            Mock<IPoemSyntaxRuleDocument> mockDocument = new Mock<IPoemSyntaxRuleDocument>();
            mockParser.Setup(m => m.Parse(testFilePath)).Returns(mockDocument.Object);
            mockPoemGenerator.Setup(m => m.GeneratePoem(mockPoemSchema.Object, mockDocument.Object)).Returns(expectedPoemText);
            
            //Act
            PoemService poemService = new PoemService(mockParser.Object, mockPoemRepository.Object, mockConfig.Object, mockPoemGenerator.Object);
            string actualPoemText = poemService.GeneratePoem(testSchemaId);
           
            //Assert
            Assert.AreEqual(expectedPoemText, actualPoemText);

            mockPoemRepository.Verify(m => m.GetSchemaById(It.IsAny<int>()), Times.Exactly(1));
            mockConfig.Verify(mock => mock.SyntaxConfigFile, Times.AtLeast(1));
            mockParser.Verify(m => m.Parse(It.IsAny<string>()), Times.Exactly(1));
            mockPoemGenerator.Verify(m => m.GeneratePoem(It.IsAny<PoemSchema>(), It.IsAny<IPoemSyntaxRuleDocument>()), Times.Exactly(1));
        }

        [TestMethod]
        public void ServiceGetAllPoemSchemasSuccessTest()
        {
            //Arrange
            List<PoemSchema> expectedSchemas = new List<PoemSchema>();
            mockPoemRepository.Setup(m => m.GetAllSchemas()).Returns(expectedSchemas);
            PoemService poemService = new PoemService(mockParser.Object, mockPoemRepository.Object, mockConfig.Object, mockPoemGenerator.Object);
            
            //Act
            List<PoemSchema> actualSchemas = poemService.GetAllPoemSchemas();

            //Assert
            Assert.AreEqual(expectedSchemas, actualSchemas);

            mockPoemRepository.Verify(m => m.GetAllSchemas(), Times.Exactly(1));
        }
    }
}
