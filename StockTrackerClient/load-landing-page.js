var container;
var usernameInput;

$(document).ready(function(){
    initializeRegistrationContainer();
    createUsername();
    createPassword();
    createRegistration();

    initializeLoginContainer();
});

var initializeRegistrationContainer = function() {
    container = $('<div>Register</div>', {id: 'container'});
    
    $('body').append(container);
}

function createUsername() {
    var usernameContainer = $('<div></div>', {id: 'usernameContainer'});
    var usernameLabel = $('<label>username: </label>');
    usernameInput = $('<input type="text" />')
        .attr('id', 'username');
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
    var usernameText = $('#username').val();
    var passwordText = $('#password').val();

    var registrationCredentials =
        {
            'userName': usernameText,
            'password': passwordText,
            'confirmPassword': passwordText
        };

    console.log(registrationCredentials);

    // $.ajax({
    //     type: 'post',
    //     url: 'http://localhost:22447/api/account/register',
    //     data: registrationCredentials,
    //     contentType: 'application/json',
    //     dataType: 'json'
    // });

    $.post('http://localhost:22447/api/account/register', registrationCredentials);
}

var initializeLoginContainer = function() {
    container = $('<div>Login</div>')
        .attr('id', 'login-container');
    
    $('body').append(container);

    username = $('<div>')
        .attr('id', 'login-username');
    
    usernameLabel = $('<label>username: </label>');
    usernameInput = $('<input>')
        .attr('id', 'login-username-input');

    username.append(usernameLabel);
    username.append(usernameInput);

    password = $('<div>')
        .attr('id', 'login-password');

    passwordLabel = $('<label>password: </label>');
    passwordInput = $('<input>')
        .attr('id', 'login-password-input');

    password.append(passwordLabel);
    password.append(passwordInput);
    
    container.append(username);
    container.append(password);

    login = $('<button>login</button>')
        .attr('onClick', 'loginWithCredentials()');

    container.append(login);
}



function loginWithCredentials() {
    username = $('#login-username-input').val();
    password = $('#login-password-input').val();

    var credentials = {
        username: username,
        password: password,
        grant_type: 'password'
    };

    $.post('http://localhost:22447/token', credentials)
        .done(function(results) {
            console.log(results);
        });
}