// Write your Javascript code.




var config = {
    authority: "http://localhost:5000",
    client_id: "client3",
    redirect_uri: "http://localhost:5003/About",
    popup_redirect_uri: "http://localhost:5003/About",
    reponse_type: "id_token token",
    scope: "openid profile MyFirstApi"
};

var manager = new Oidc.UserManager(config);

manager.getUser().then(function (user) {
    debugger
    if (user) {
        alert("User " + user.profile)
    }
})


function login() {
    debugger

    manager.signinPopup();
  //  manager.signinRedirect();
}

function log() {

    document.getElementById("result").innerText = "";

    //Array.prototype.forEach.call(arguments, function (msg) { 

    //    function  (msg) {
    //        if (msg instanceof Error) {
    //            msg = "Error: " + msg.message;
    //        }
    //        else if (typeof msg !== "string") {
    //            msg = JSON.stringify(msg, null, 2);
    //        }
    //        document.getElementById("result").innerHTML += msg + "\r \n";
    //    }
    //})
}


function api() {

    manager.getUser().then(function (user) {

        var url = "http://localhost:5001";
        var xhr = new XMLHttpRequest();
        xhr.open("GET", url);

        xhr.onload = function () {

            log(xhr.status, JSON, parse(xhr.responseText));
        }
        xhr.setRequestHeader("Authorization", "Bearer" + user.access_token);
        xhr.send();
    })
}

    //}

