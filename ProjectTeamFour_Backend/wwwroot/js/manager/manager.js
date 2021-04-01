////var loginApp = new Vue({

let btnLogin = document.querySelector(".btn-login");
let jwtAuthUrl = "https://localhost:44344/api/Manager/Login";

btnLogin.addEventListener("click", function () {
    let name = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    let user = {
        Username: name, Password: password
    }
    $.ajax({
        url: jwtAuthUrl,
        method: "POST",
        dataType: "json",
        data: JSON.stringify(user),
        contentType: "application/json;charset=UTF-8",   
        success: function (response) {
            console.log(response)
            localStorage.setItem("jwtToken", response.token);

            $("#token").html("JWT Token: " + response.token);
        },
        error: function (ex) {
            console.log(ex)
        }
    })
});


