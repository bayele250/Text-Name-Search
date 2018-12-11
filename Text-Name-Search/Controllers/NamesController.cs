using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Text_Name_Search.Models;


namespace Text_Name_Search.Controllers
{
    public class NamesController : Controller
    {
        // GET: Names
        static List<Names> namesList = new List<Names>();
        static List<string> countedNameList = new List<string>();
        static List<Article> article = new List<Article>();
        static int nameOccurrences = 0;
        static int initialIndex = 0;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllNames());
        }

        IEnumerable<Names> GetAllNames()
        {
            return namesList.ToList();
        }


        public ActionResult AddName(string firstName = "", string lastName = "", string middleName = "")
        {
            Names names = new Names();
            //
            return View(names);
        }

        [HttpPost]
        public ActionResult AddName(Names names)
        {

            namesList.Add(new Names() { FirstName = names.FirstName, LastName = names.LastName, MiddleName = names.MiddleName});
            TempData["NameForSearch"] = namesList.ToList();
                      
            return RedirectToAction("ViewAll");
        }

    }
}