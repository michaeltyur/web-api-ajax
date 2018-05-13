function renderSelectedRecipe(recipe)
{
    $("#sel-recipe-title").text("Selected Recipe");
    $("#recipeId").val(recipe.Id);
    $("#recipeName").val(recipe.Name);
    $("#recipeDescription").val(recipe.Description);
    $("#ingredients").val(recipe.Ingredients);
    $("#image-src").val(recipe.Image);
    $("#update-button").val("Update");
}

function getSelectedRecipe(id)
{
    getRecipe(id, renderSelectedRecipe);
    $(".recipe-out").css("background-color", "white");
    $("#recipe-out"+id).css("background-color", "#afa3de");
    var el = $("#recipe-out" + id);
}

function updateSelectedRecipe()
{
    var id = $('#recipeId').val();
    var name = $('#recipeName').val();
    var description = $('#recipeDescription').val();

    var ingredientsStr = $('#ingredients').val();
    var image = $('#image-src').val();

    if (!name)
    {
        alert("The name can not be empty");
        //$('.error').show();
        return;
    }
    else if (!description){
        alert("The description can not be empty");
        return;
        //$('.error').hide();
    }

    var recipe =
        {
            Name:name,
            Description:description,
            Ingredients: ingredientsStr,
            Image:image
        }

        //new Recipe(name, description);

    if (id==="") {
        newRecipe(recipe, renderEl)
    }
    else {
        updateRecipe(id, recipe, renderEl);
    }
}

//Auxiliary methods

function clearFields()
{
    $("#sel-recipe-title").text("New Recipe");
    $("#recipeId").val("");
    $("#recipeName").val("");
    $("#recipeDescription").val("");
    $("#ingredients").val("");
    $("#image-src").val("");
    $("#update-button").val("New Recipe");
}

function notEditableElem()
{
    $("#recipeName").attr("readonly", true);
    $("#recipeDescription").attr("readonly", true);
    $("#ingredients").attr("readonly", true);
    $("#image-src").attr("readonly", true);
}
