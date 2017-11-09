using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PoemGenerator.Utils
{
    public class Config
    {
        public virtual string SyntaxConfigFile
        {
            get
            {
                return Path.Combine(HostingEnvironment.MapPath(@"~/App_Data"), ConfigurationManager.AppSettings["SyntaxConfigFile"]);
            }
        }

        public virtual int MaxSyllablesCount
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["MaxSyllablesCount"]);
            }
        }
    }
}