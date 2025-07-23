using E_Project_James_Thew.Data;
using E_Project_James_Thew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Project_James_Thew.Controllers
{
    public class ClientController : Controller
    {


        private readonly ChefJamesDbContext db;
        public ClientController(ChefJamesDbContext db)
        {
            this.db = db;
        }


        //------------ HOME PAGE --------
        public IActionResult Index()
        {
            return View();
        }




        //---------- FREE RECIPES PAGE -----------
        public IActionResult freeRecipes()
        {
            var recipe = db.Recipes.Where(r => r.RecipeStatus == "Free").ToList();
            return View(recipe);
        }


        //---------------- PREMIUM RECIPES PAGE ---------------
        public IActionResult PremiumRecipes()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            // Check if the logged-in email exists in Membership table
            bool isMember = db.Memberships.Any(m => m.MEmail == email);

            List<Recipe> premiumRecipes = new List<Recipe>();
            if (isMember)
            {
                premiumRecipes = db.Recipes
                    .Where(r => r.RecipeStatus == "Premium")
                    .ToList();
            }

            ViewBag.IsMember = isMember;
            return View(premiumRecipes);
        }






        //----------------- FULL RECIPES ------------------
        public IActionResult FullRecipe(int id)
        {
            var recipe = db.Recipes.FirstOrDefault(r => r.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }




        //---------------- CONTEST PAGE ---------------
        public IActionResult contest()
        {
            var contest = db.Contests.OrderByDescending(c => c.ContestId).ToList();
            return View(contest);
        }




        //---------------- ANNOUNCEMENT PAGE ---------------
        public IActionResult announcement()
        {
            var announcements = db.Announcements.OrderByDescending(a => a.AId).ToList();
            return View(announcements);
        }



        //---------------- MEMBERSHIP PAGE ---------------
        public IActionResult membership()
        {
            return View();
        }


        [HttpPost]
        public IActionResult membership(Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Memberships.Add(membership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membership);
        }



        //------------------ LOGIN/REG PAGE ------------------
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult login(UserAccount newUser)
        {
            var matchUser = db.UserAccounts.FirstOrDefault(u => u.UserEmail == newUser.UserEmail && u.UserPassword == newUser.UserPassword);

            if (matchUser != null)
            {
                HttpContext.Session.SetString("UserEmail", matchUser.UserEmail);
                return RedirectToAction("Index", "Client");
            }


            ViewBag.loginError = "Invalid email or password.";
            return View("login");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Client");
        }



        [HttpPost]
        public IActionResult Register(UserAccount newUser)
        {
            if (ModelState.IsValid)
            {
                var checkUser = db.UserAccounts.FirstOrDefault(u => u.UserEmail == newUser.UserEmail);
                if (checkUser != null)
                {
                    ViewBag.Error = "User with this email already exist !!!";
                    return View("Login");
                }

                newUser.RId = 2;
                db.UserAccounts.Add(newUser);
                db.SaveChanges();

                ViewBag.Success = "Registration successful! You can now log in.";
                return View("Login");

            }

            return View();
        }



        //-------------------- CONTACT PAGE ---------------------
        public IActionResult contact()
        {
            return View();
        }



        //---------------------- FEEDBACK PAGE ---------------------
        public IActionResult feedback()
        {
            return View();
        }




        //----------------------- PARTICIPATE IN CONTEST PAGE ------------------
       public IActionResult participate()
        {
            return View();
        }




    }
}
