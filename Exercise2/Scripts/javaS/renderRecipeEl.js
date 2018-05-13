var listRecipes = {
    data: null
}

function renderEl(listRecipes)
{
    renderRecipes(listRecipes);
    clearFields();
    listRecipes.data = listRecipes;
}

function renderRecipes(data) {
    $("#recipes-list").empty();
    $("#recipes-list").append(`<h3 class="recipes-title">Our Recipes</h3>`);
    for (var i = 0; i < data.length; i++)
    {
        addRecipes(data[i]);
    }
}

function addRecipes(recipe)
{

    $("#recipes-list").append(`<div onclick=getSelectedRecipe(${recipe.Id}) id="recipe-out${recipe.Id}" class ="recipe-out">
                                       <div class ="recipe-in">
                                          <img class ="recipe-img" src="${recipe.Image}"/>
                                          <h3> ${recipe.Name}</h3>
                                          <h4>${recipe.Description}</h4>
                                          <h4 >Ingredients: <span class="ingredients">${recipe.Ingredients}</span></h4>
                                          <div class ="recipe-buttons-div">
                                            <input type="button" id="buy-ingredients-button" class ="buttons recipe-buttons" value="Buy Ingredients" onclick="getIngriediensForBuy(${recipe.Id})">
                                            <input type="button" id="delete-recipe" class ="buttons recipe-buttons" value="Delete" onclick="deleteSelectedRecipe(${recipe.Id})">
                                          </div>
                                      </div>
                                </div>`);
}

//function getIngredients(recipe)
//{
//    if (!recipe && !recipe.Ingredients) {
//        return "Not information";
//    }
//    var ingredients = "";
//    for (var i = 0; i < recipe.Ingredients.length; i++)
//    {
//        ingredients += recipe.Ingredients[i];
//        if (i < recipe.Ingredients.length-1)
//            ingredients += ",";
//    }
   
//    return ingredients;
//}

function getIngriediensForBuy(id)
{
    buyIngrediens(id);
    window.location = '/ShopItem/ShopList';
}

function recievRecipe(recipe)
{
    var rc = recipe;
}

//Delete Recipe
function deleteSelectedRecipe(id)
{
    if(confirm("are you sure to delete this recipe"))
       deteleRecipe(id, renderEl);
}