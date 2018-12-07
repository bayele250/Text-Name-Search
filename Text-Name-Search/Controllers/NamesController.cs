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
            
            return View(names);
        }

        [HttpPost]
        public ActionResult AddName(Names names )
        {

            namesList.Add(new Names() { FirstName = names.FirstName, LastName = names.LastName, MiddleName = names.MiddleName});
            SearchName(namesList, article);
            TempData["nameFound"] = countedNameList.ToList();
            
            return RedirectToAction("ViewAll");
        }
        IEnumerable<Article> GetAllArticles()
        {
            return article.ToList();
        }
        [HttpPost]
        public ActionResult AddArticle(Article articleData )
        {
            article.Add(new Article() { Articles = articleData.Articles });
            
            return RedirectToAction("AllArticle");
        }

        public ActionResult AddArticle(string article = "")
        {
            Article art = new Article();
            return View(art);
        }
        public ActionResult AllArticle()
        {
            return View(GetAllArticles());
        }


       void SearchName(List<Names> allNames, List<Article> articl)
        {
            string allArticle = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas Connor Smith dignissim erat consequat, placerat erat in, lobortis nulla. Vestibulum scelerisque magna ut urna hendrerit, finibus rutrum dolor faucibus. Seth David Greenly Aliquam feugiat urna vel tellus congue, non dictum orci varius. Vivamus tristique, lorem ut hendrerit aliquet, nulla nisl eleifend quam, sed laoreet erat lorem non diam. Nulla facilisi. Etiam bibendum Seth D. Greenly nec diam sed vestibulum. Nunc ipsum enim, imperdiet eu feugiat vel, vestibulum a justo. Donec efficitur velit porta odio consequat viverra. Quisque in tristique enim, sed euismod purus. Nullam eu leo pellentesque, porta leo in, Sarah Greenly maximus risus. Morbi in risus id risus feugiat egestas. David black Nunc egestas, metus at volutpat tempus, massa justo venenatis arcu, a ornare mauris arcu at justo. Sed accumsan, David W. black erat vitae euismod facilisis, risus odio bibendum neque, sit amet tincidunt diam ante et dolor. Morbi leo felis, posuere id ex ut, varius ornare libero.Suspendisse lacus ipsum, molestie vel nulla id, commodo hendrerit est. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Maecenas finibus magna libero, vehicula David Black luctus lorem varius non. Integer ut tempor massa, eget sollicitudin purus. Mauris efficitur in ipsum eu consectetur.Aliquam vitae nulla vitae sapien laoreet vehicula et et ex. Donec molestie auctor lorem eget Seth rhoncus.Donec ornare sapien in turpis auctor, ut commodo David Warren Black augue cursus. Pellentesque fermentum nunc turpis, eu vulputate Connor Smith leo aliquet eu. Nam quis pretium felis. Sed id turpis sed lacus malesuada pulvinar et eget leo. Vestibulum eget dapibus mi. Duis tempor nec tellus vitae aliquet. Nam sapien massa, ornare non posuere sit amet, cursus a velit.Curabitur nec consectetur metus. Donec porttitor at libero a blandit.Proin luctus augue sit amet sem varius ultricies. Vestibulum nibh ligula, sollicitudin ac lectus eu, congue imperdiet quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Nulla ac nisl sed risus tincidunt finibus.Curabitur viverra eget justo non dignissim. Seth D Greenly Proin varius malesuada enim non vulputate.Integer fermentum interdum felis, luctus commodo nisi pulvinar quis.Donec pharetra faucibus urna a semper. Morbi tempor maximus Connor G Smith lectus sit amet interdum. Integer pretium ut est non vulputate. Aliquam pulvinar turpis laoreet dictum ultrices. Aenean diam metus, David semper at quam et, iaculis viverra ante.Sed efficitur lorem quis consectetur mollis. Vivamus ut purus mauris. Quisque at gravida dolor. Fusce congue magna enim, ut placerat est porttitor a. Phasellus rutrum, neque lacinia Gary Grossman cursus mattis, est lacus placerat nunc, a ornare enim nunc at justo.Sed urna leo, tincidunt elementum consequat vel, condimentum sed lacus.";

            foreach (var text in articl)
            {
                allArticle += " " + text;
            }

            nameOccurrences = 0;
            initialIndex = 0;

            foreach (var names in allNames)
            {
                var fullname = names.FirstName.ToString() + " " + names.MiddleName.ToString() + " " + names.LastName.ToString();
                
                while (((initialIndex = allArticle.IndexOf(fullname)) >= 0))
                {   
                    ++initialIndex;
                    ++nameOccurrences;
                }

               countedNameList.Add(fullname + " mentioned " + nameOccurrences.ToString() + " times.");
            }
            
        }

    }
}