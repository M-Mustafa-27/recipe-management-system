using System;
using System.Collections.Generic;

namespace E_Project_James_Thew.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string RecipeName { get; set; } = null!;

    public string RecipeCategory { get; set; } = null!;

    public string? RecipeDescription { get; set; }

    public string RecipeStatus { get; set; } = null!;

    public string? RecipeImage { get; set; }

    public string? RecipeIngredients { get; set; }

    public string? FullRecipe { get; set; }
}
