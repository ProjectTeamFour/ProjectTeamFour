

let btnLogin = document.querySelector(".btn-login");
let jwtAuthUrl = "/api/Manager/Login";

btnLogin.addEventListener("click", function () {
    let mail = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let user = {
        MemberRegEmail: mail, Password: password
    }
    $.ajax({
        url: jwtAuthUrl,
        method: "POST",
        dataType: "json",
        data: JSON.stringify(user),
        contentType: "application/json;charset=UTF-8",
        success: function (response) {
          
        localStorage.setItem("jwtToken", response.token);
            Cookies.set("jwtToken", response.token);
            $("#token").html("JWT Token: " + response.token);
            AfterLogin();

        },
        error: function (ex) {
            console.log(ex)
        }
    });

    function AfterLogin() {
        window.location.href = '/Home/Index';
    }
});


