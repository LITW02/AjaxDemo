using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication26.Controllers
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class RandomNumber
    {
        public RandomNumber()
        {
            People = new List<Person>();
            People.Add(new Person { Name = "Avrumi", Age = 34 });
            People.Add(new Person { Name = "John", Age = 45 });
        }
        public int Number { get; set; }
        public int[] Nums { get; set; }
        public List<Person> People { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRandom(int min, int max)
        {
            Random rnd = new Random();
            int num = rnd.Next(min, max);
            RandomNumber randomNum = new RandomNumber();
            randomNum.Number = num;
            int[] nums = new int[rnd.Next(10, 20)];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rnd.Next(min, max);
            }
            randomNum.Nums = nums;
            return Json(randomNum, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckUsername(string username)
        {
            var obj = new { isGood = username.Length == 5};

            return Json(obj, JsonRequestBehavior.AllowGet);


        }
    }
}
