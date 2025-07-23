using E_Project_James_Thew.Data;
using E_Project_James_Thew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Project_James_Thew.Controllers
{
    public class AdminController : Controller
    {

        private readonly ChefJamesDbContext db;
        public AdminController(ChefJamesDbContext db)
        {
            this.db = db;
        }



        public IActionResult dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult addRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe, IFormFile RecipeImage)
        {
            if (RecipeImage != null && RecipeImage.Length > 0)
            {
                // Save image to wwwroot/images/recipes/
                var fileName = Path.GetFileName(RecipeImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/recipes", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    RecipeImage.CopyTo(stream);
                }

                // Store relative path or just filename
                recipe.RecipeImage = "/images/recipes/" + fileName;
            }

            db.Recipes.Add(recipe);
            db.SaveChanges();

            return RedirectToAction("AddRecipe");
        }




        [HttpGet]
        public IActionResult RecipeList()
        {
            var allRecipes = db.Recipes.ToList();
            return View(allRecipes);
        }

        [HttpGet]
        public IActionResult EditRecipe(int id)
        {
            var recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost]
        public IActionResult EditRecipe(Recipe updatedRecipe)
        {
            db.Recipes.Update(updatedRecipe);
            db.SaveChanges();
            return RedirectToAction("RecipeList");
        }


        public IActionResult DeleteRecipe(int id)
        {
            var recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("RecipeList");
        }





        [HttpGet]
        public IActionResult addContest()
        {
            return View();
        }



        [HttpGet]
        public IActionResult contentList()
        {
            return View();
        }


        [HttpGet]
        public IActionResult addAnnouncement()
        {
            return View();
        }


        [HttpGet]
        public IActionResult announcementList()
        {
            return View();
        }


        [HttpGet]
        public IActionResult feedback()
        {
            return View();
        }



    }
}
