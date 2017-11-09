using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PoemGenerator.Utils
{
    public class FileReader
    {
        public virtual string ReadTextFromFile(string fileName)
        {
            string text = "";
            using (StreamReader file = new StreamReader(fileName))
            {
                text = file.ReadToEnd();
            }

            return text;
        }
    }
}