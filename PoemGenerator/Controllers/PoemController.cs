using Ninject;
using PoemGenerator.Models;
using PoemGenerator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoemGenerator.Controllers
{
    public class PoemController : Controller
    {
        IPoemService poemService;

        public PoemController(IPoemService poemService)
        {
            this.poemService = poemService;
        }

        public ActionResult Index()
        {
            List<PoemSchema> schemas = poemService.GetAllPoemSchemas();
            ViewBag.PoemSchemas = schemas;
            return View();
        }

        public ActionResult GetPoem(int schemaId)
        {
            string poem = poemService.GeneratePoem(schemaId);

            return Content(poem);
        }

    }
}
