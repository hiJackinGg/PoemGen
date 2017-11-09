using Ninject.Modules;
using PoemGenerator.BL;
using PoemGenerator.BL.PoemGeneration;
using PoemGenerator.BL.RandomGenerators;
using PoemGenerator.BL.RandomGenerators.Impl;
using PoemGenerator.BL.SyntaxRules;
using PoemGenerator.DAL;
using PoemGenerator.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoemGenerator.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDictionaryRepository>().To<PoemRepository>();
            Bind<ISchemaRepository>().To<PoemRepository>();
            Bind<IPoemRepository>().To<PoemRepository>();
            Bind<IPoemService>().To<PoemService>();
            Bind<IPoemSyntaxRulesParser>().To<PoemSyntaxRulesParser>();
            Bind<IPoemSyntaxRuleDocument>().To<PoemSyntaxRuleDocument>();
            Bind<IFootRandomGenerator>().To<FootRandomGenerator>();
            Bind<INodeRandomGenerator>().To<NodeRandomGenerator>();
            Bind<IWordRandomGenerator>().To<WordRandomGenerator>();
            Bind<IPoemGen>().To<PoemGen>();
            Bind<Converter>().To<Converter>();
            Bind<Config>().To<Config>();
            Bind<FileReader>().To<FileReader>();
        }
    }
}