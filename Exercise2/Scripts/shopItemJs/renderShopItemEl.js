//var totalAmount = {};
//    key:null,
//    data: null
//}
var checkAll = 0;

function renderShopItemsPage(itemsList)
{
    renderItemsEl(itemsList);
}
function renderItemsEl(itemsList)
{
    checkAll = 0;
    $("#shopitem-list").empty();

    if (itemsList.length === 0)
    {
        $("#checkbox-all").prop('checked', false);
        $("#shopitem-list").append(`<h2 id="alert-shopItems" >Shop List Is Empty</h2>`);
        return;
    }

    for (var i = 0; i < itemsList.length; i++) {
        addItems(itemsList[i], checkAll);
        if (itemsList[i].IsBought) checkAll++;
    }
    if (checkAll === itemsList.length) $("#checkbox-all").prop('checked', true);
    else $("#checkbox-all").prop('checked', false);
}

function addItems(item) {
    $("#shopitem-list").append(`<div class="item-div" id="item-div${item.Id}" >
                                  <div class ="checkbox-div">
                                     <input class ="checkbox" id="checkbox${item.Id}" type="checkbox" onclick="itemState(${item.Id})"/>
                                  </div>
                                  <div class ="item-info-div" id="item-info-div${item.Id}" onclick="getItemById(${item.Id})" >
                                    <h3>${item.Name}&nbsp(${item.Amount}) </h3>
                                    <h4>${item.Description}</h4>
                                  </div>
                                  <div class ="delete-item-div">
                                    <input type="button" class ="buttons delete-item" value="Del" onclick="deleteItem(${item.Id})" />
                                  </div>
                                  <div class ="done-div">
                                    <h3 class="done">${done(item)}</h3>
                                  </div>
                                </div>`);
    if (item.IsBought)
    {
        $("#checkbox" + item.Id).prop('checked', true);
        $("#item-info-div" + item.Id).css('background-image', 'url(' + "/Images/done.jpeg" + ')');
        $("#item-info-div" + item.Id).css("background-size", "contain");
    }
    
    
}

//Auxiliary Methods

function done(item)
{
    var result="Done";
    if (item.IsBought) return result;
    else return "Not " + result;
}

function itemStateAll()
{
    var checked;
    //checkAll = !checkAll;
    if( $("#checkbox-all").is(":checked"))
        checked = true;
    else checked = false;
    //if ($("#checkbox-all").is(':checked'))
    //    checked = true;
    //else checked = false;
    changeAllItemState(checked, renderShopItemsPage);
}

function itemState(id)
{   
    var itemDiv = $("#item-div" + id);
    changeItemState(id, renderShopItemsPage)
}

function getItemById(id)
{
    gettItem(id, renderSelectedItem);
}
function renderSelectedItem(item)
{
    $("#itemId").val(item.Id);
    $("#itemName").val(item.Name);
    $("#itemDescription").val(item.Description);
    $("#amount").val(item.Amount);
    $("#item-button").val("Update");
}

function updateOrCreateItem()
{
    var id = $('#itemId').val();
    var name = $('#itemName').val();
    var amount = $('#amount').val();
    if (!amount) amount = 1;
    var description = $('#itemDescription').val();

    if (!name) {
        alert("The name can not be empty");
        //$('.error').show();
        return;
    }
    var item =
        {
            Name : name,
            Description : description,
            Amount : amount
        }
    //new ShopItem(name, description);

    if (id === "") {
        newItem(item, renderShopItemsPage)
    }
    else {
        updateItem(id, item, renderShopItemsPage);
    }
    clearItemFields();
}


function clearItemFields()
{
    $("#itemId").val("");
    $("#itemName").val("");
    $("#itemDescription").val("");
    $("#amount").val("");
    $("#item-button").val("Add");

}

function clearAllAmount()
{
    clearAmountItems(renderShopItemsPage);
}

function removeAll() {
    removeAllItems(renderShopItemsPage);
}

function deleteItem(id)
{
    deteleShopItem(id, renderShopItemsPage);
}