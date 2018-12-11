using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Text_Name_Search.Models;

namespace Text_Name_Search.Controllers
{
    public class SearchController : Controller
    {
        static List<Article> article = new List<Article>();
        string articlesAsString = "";
        // GET: Search
        public ActionResult Index()
        {
            Article newArticle = new Article();
            return View(newArticle);
        }

        public ActionResult Articles()
        {
            return View(GetAllArticles());
        }

        [HttpPost]
        public ActionResult Articles(Article addArticle)
        {
            try
            {
                article.Add(addArticle);
                articlesAsString = string.Join(" ", article);
                return RedirectToAction("Articles");
            }
            catch (Exception)
            {
                return View();
            }
            
        }
        IEnumerable<Article> GetAllArticles()
        {
            return article.ToList();
        }

        public ActionResult NamesOccured()
        {
            try
            {
                List<Names> names= TempData["NameForSearch"] as List<Names>;
                foreach (var item in article)
                {
                    articlesAsString = articlesAsString + item.ToString();
                }
                //articlesAsString = string.Join(" ", article);
                int len = articlesAsString.Length;
                List<Article> articles = TempData["ArticleContent"] as List<Article>;

                return View(SearchName(names));
            }
            catch (Exception)
            {

                return RedirectToAction("Articles");
            }         
        }

        public IEnumerable<ArticleNames> SearchName(List<Names> allNames)
        {

            List<NamePatterns> nameOptions = new List<NamePatterns>();
            List<ArticleNames> namesInArticle = new List<ArticleNames>();

            foreach (var namelist in allNames)
            {
                NamePatterns namePatterns = new NamePatterns()
                {
                    FullPattern = namelist.FirstName.ToString() + " " + namelist.MiddleName.ToString() + " " + namelist.LastName.ToString(),
                    FirstLastPattern = namelist.FirstName.ToString() + " " + namelist.LastName.ToString(),
                    FullInitialPattern = namelist.FirstName.ToString() + " " + namelist.MiddleName.Substring(0, 1).ToString() + " " + namelist.LastName.ToString(),
                    FullInitialDotPattern = namelist.FirstName.ToString() + " " + namelist.MiddleName.Substring(0, 1).ToString() + ". " + namelist.LastName.ToString(),
                };

                nameOptions.Add(namePatterns);
            }

            foreach (var patters in nameOptions)
            {

                int counts= 0;
                string[] name = new string[4];

                name[0] = patters.FullPattern;
                name[1] = patters.FirstLastPattern;
                name[2] = patters.FullInitialPattern;
                name[3] = patters.FullInitialDotPattern;

                foreach (var word in name)
                {
                    //Text Content is added here for sample data
                    string st = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas Connor Smith dignissim erat consequat, placerat erat in, lobortis nulla. Vestibulum scelerisque magna ut urna hendrerit, finibus rutrum dolor faucibus. Seth David Greenly Aliquam feugiat urna vel tellus congue, non dictum orci varius. Vivamus tristique, lorem ut hendrerit aliquet, nulla nisl eleifend quam, sed laoreet erat lorem non diam. Nulla facilisi. Etiam bibendum Seth D. Greenly nec diam sed vestibulum. Nunc ipsum enim, imperdiet eu feugiat vel, vestibulum a justo. Donec efficitur velit porta odio consequat viverra. Quisque in tristique enim, sed euismod purus. Nullam eu leo pellentesque, porta leo in, Sarah Greenly maximus risus. Morbi in risus id risus feugiat egestas. David black Nunc egestas, metus at volutpat tempus, massa justo venenatis arcu, a ornare mauris arcu at justo. Sed accumsan, David W. black erat vitae euismod facilisis, risus odio bibendum neque, sit amet tincidunt diam ante et dolor. Morbi leo felis, posuere id ex ut, varius ornare libero. Suspendisse lacus ipsum, molestie vel nulla id, commodo hendrerit est. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Maecenas finibus magna libero, vehicula David Black luctus lorem varius non. Integer ut tempor massa, eget sollicitudin purus. Mauris efficitur in ipsum eu consectetur.Aliquam vitae nulla vitae sapien laoreet vehicula et et ex. Donec molestie auctor lorem eget Seth rhoncus.Donec ornare sapien in turpis auctor, ut commodo David Warren Black augue cursus. Pellentesque fermentum nunc turpis, eu vulputate Connor Smith leo aliquet eu. Nam quis pretium felis. Sed id turpis sed lacus malesuada pulvinar et eget leo. Vestibulum eget dapibus mi. Duis tempor nec tellus vitae aliquet. Nam sapien massa, ornare non posuere sit amet, cursus a velit.Curabitur nec consectetur metus. Donec porttitor at libero a blandit. Proin luctus augue sit amet sem varius ultricies. Vestibulum nibh ligula, sollicitudin ac lectus eu, congue imperdiet quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Nulla ac nisl sed risus tincidunt finibus.Curabitur viverra eget justo non dignissim. Seth D Greenly Proin varius malesuada enim non vulputate.Integer fermentum interdum felis, luctus commodo nisi pulvinar quis. Donec pharetra faucibus urna a semper. Morbi tempor maximus Connor G Smith lectus sit amet interdum. Integer pretium ut est non vulputate. Aliquam pulvinar turpis laoreet dictum ultrices. Aenean diam metus, David semper at quam et, iaculis viverra ante.Sed efficitur lorem quis consectetur mollis. Vivamus ut purus mauris. Quisque at gravida dolor. Fusce congue magna enim, ut placerat est porttitor a. Phasellus rutrum, neque lacinia Gary Grossman cursus mattis, est lacus placerat nunc, a ornare enim nunc at justo.Sed urna leo, tincidunt elementum consequat vel, condimentum sed lacus.";

                    int num = st.Length;
                    int initindex = 0;
                    int last = st.Length;

                    while (last > -1)
                    {
                        last = st.ToLower().LastIndexOf(word.ToLower());
                        if (last > -1)
                        {
                            ++counts;
                            st = st.Substring(initindex, last).ToLower();
                        }
                    }
                }

                ArticleNames occurance = new ArticleNames()
                {
                    FullName = name[0],
                    TotalOccurance = counts
                };

                namesInArticle.Add(occurance);
            }
            return namesInArticle;
        }
    }
}