
window.onload = function () {
    var checkAll = false;
    gettAllRecipes(renderEl);
    gettAllItems(renderShopItemsPage);
}

//Gett all items
function gettAllRecipes(callback) {
    $.ajax({
        url: "/api/Recipe",
        method: 'Get',
        dataType: 'json'
     }).done(callback)
}

//Find the item
function getRecipe(id,callback) {
    $.ajax({
        method: "GET",
        url: "/api/Recipe/" + id,
     }).done(callback);
}

//Update the item
function updateRecipe(id, item, callback) {
   $.ajax({
        method: "PUT",
        url: "/api/Recipe/" + id,
        data: item,
        error: function (response) {
            alert(response.responseText);

        }
    }).done(callback);

}

//Create new item
function newRecipe(item, callback) {
    $.ajax({
        method: "POST",
        url: "/api/Recipe",
        dataType: 'json',
        data: item,
        error: function (response) {
            alert(response.responseText);
            window.location = '/Account/Login';
        }
    }).done(callback);
}

//Delete the item
function deteleRecipe(id, callback)
{
    $.ajax
     ({
         method: "DELETE",
         url: "/api/Recipe/" + id,
         error: function (response) {
             alert(response.responseText);
         }
     }).done(callback);
}

function buyIngrediens(id)
{
    $.ajax({
        method: "POST",
        url: "api/buyIngrediens/"+id,
        dataType: 'json',
    }).done();
}
