function loginFieldsValidation() {
    var userName = $("#userName").val();
    var password = $("#password").val();

    if (!userName||!password) {
        alert("The fields can not be empty");
        return;
    }

    var user = {
        UserName: userName,
        Password: password
    }

    login(user);
    gettAllRecipes(renderEl);
}
function renderAuthUser(user)
{
    $("#login-div").empty();
    if (user)
    {
        $("#login-div").append(`<div>
                                   <h4>Wellcome, ${user.UserName}</h4>
                                 </div>
                                 <div>
                                   <input type="button" id="logout-button" class ="log-buttons" value="sign out" onclick="logout()">
                                 </div>`)
    }
    else {
        $("#login-div").append(`<label for="userName">user name:&nbsp</label>
                                <input type="text" id="userName" class="login-input">
                                <label for="password">password:&nbsp</label>
                                <input type="password" id="password" class="login-input">
                                <input type="button" id="login-button" class="log-buttons" value="sign in" onclick="loginFieldsValidation()">`);
    }
}

//function logoutclick()
//{

//}