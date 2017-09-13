var container;
var usernameInput;

$(document).ready(function(){
    initializeContainer();
    createUsername();
    createPassword();
    createRegistration();
});

var initializeContainer = function() {
    container = $('<div></div>', {id: 'container'});
    
    $('body').append(container);
}

function createUsername() {
    var usernameContainer = $('<div></div>', {id: 'usernameContainer'});
    var usernameLabel = $('<label>username: </label>');
    usernameInput = $('<input type="text" />', {id: 'username'});
    $(usernameContainer).append(usernameLabel, usernameInput);

    $(container).append(usernameContainer);
}

var createPassword = () => {
    var passwordContainer = $('<div></div>', {id: 'passwordContainer'});
    var passwordLabel = $('<label>password: </label>');
    $(passwordContainer).append(passwordLabel, passwordInput);

    var passwordInput = $("<input>")
        .attr("type", "password")
        .attr("id", "password")
        .appendTo(passwordContainer);

    $(container).append(passwordContainer);
}

function createRegistration() {
    var registerButton = '<button onClick="register()" >register</button>';

    $(container).append(registerButton);
}

function register() {
    console.log($('#password').val());
}


