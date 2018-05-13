

//Gett all items
function gettAllItems(callback) {
    $.ajax({
        url: "/api/ShopItem",
        method: 'Get',
        dataType: 'json'
    }).done(callback)
}

//get selected item
function gettItem(id,callback) {
    $.ajax({
        url: "/api/ShopItem/"+id,
        method: 'Get',
        dataType: 'json'
    }).done(callback)
}

//Update the item
function updateItem(id,item, callback) {
    $.ajax({
        method: "PUT",
        url: "/api/ShopItem/" + id,
        data:item
    }).done(callback);
}

//change item state
function changeItemState(id, callback) {
    $.ajax({
        method: "PUT",
        url: "/api/changeState/" + id
    }).done(callback);
}

//change all item state
function changeAllItemState(check, callback) {

    if (!check)
        id = 0;
    else id = 1;

    $.ajax({
        method: "PUT",
        url: "/api/changeStateAll/" + id,
        dataType: 'json'
    }).done(callback);
}
//Create new item
function newItem(item, callback) {
    $.ajax({
        method: "POST",
        url: "/api/ShopItem",
        dataType: 'json',
        data: item
    }).done(callback);
}

//clear Amount for all items
function clearAmountItems(callback)
{
        $.ajax({
            url: "/api/clearAllAmount/",
            method: 'Get',
            dataType: 'json'
        }).done(callback)
}

//remove  all items from DB
function removeAllItems(callback) {
    $.ajax({
        url: "/api/clearAllItems/",
        method: 'Get',
        dataType: 'json'
    }).done(callback)
}

//Delete the item
function deteleShopItem(id, callback) {
    $.ajax
     ({
         method: "DELETE",
         url: "/api/ShopItem/" + id,
         error: function (response) {
             alert(response.responseText);
         }
     }).done(callback);
}