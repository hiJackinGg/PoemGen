using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemGenerator.Tests.Models
{
    [TestClass]
    public class PoemSchemaTest
    {

        [TestMethod]
        public void PoemSchemaGetLinesValidSeparator1Test()
        {
            string separator = "\\n";
            PoemSchema poemSchema = new PoemSchema();
            string testSchema = String.Format("x--x-{0}-x--x{0}-x-", separator);
            poemSchema.Value = testSchema;
            string[] expectedLines = new string[] { "x--x-", "-x--x", "-x-" };

            string[] actualLines = poemSchema.GetLines();

            CollectionAssert.AreEqual(expectedLines, actualLines);
        }

        [TestMethod]
        public void PoemSchemaGetLinesValidSeparator2Test()
        {
            string separator = "\n";
            PoemSchema poemSchema = new PoemSchema();
            string testSchema = String.Format("x--x-{0}-x--x{0}-x-", separator);
            poemSchema.Value = testSchema;
            string[] expectedLines = new string[] { "x--x-", "-x--x", "-x-" };

            string[] actualLines = poemSchema.GetLines();

            CollectionAssert.AreEqual(expectedLines, actualLines);
        }

        [TestMethod]
        public void PoemSchemaGetLinesUnrecognizableSeparatorTest()
        {
            string separator = "?";
            PoemSchema poemSchema = new PoemSchema();
            string testSchema = String.Format("x--x-{0}-x--x{0}-x-", separator);
            poemSchema.Value = testSchema;
            string[] expectedLines = new string[] { "x--x-?-x--x?-x-" };

            string[] actualLines = poemSchema.GetLines();

            CollectionAssert.AreEqual(expectedLines, actualLines);
        }
    }
}
