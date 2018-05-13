//Find the item
function login(user) {
    $.ajax({
        method: "POST",
        url: "/logApi/login",
        dataType: 'json',
        data: user,
    }).done(function (data) {
        renderAuthUser(data);
        gettAllRecipes(renderEl);
    });
}
function logout() {
    $.ajax({
        method: "POST",
        url: "/logApi/logout",
        dataType: 'json',
    }).done(function (data) {
        renderAuthUser(data);
        gettAllRecipes(renderEl);
    });
}
