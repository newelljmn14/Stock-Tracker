//ok?
renderLandingPage();

function renderLandingPage() {$(document).ready(function() {
    initializeRegistrationContainer();
    renderUsername();
    renderPassword();
    renderRegistration();

    initializeLoginContainer();
    renderStockButton();
    });
}

var initializeRegistrationContainer = function() {
    container = $('<div>Register</div>')
        .attr('id', 'container');
    
    $('body').append(container);
}

function renderUsername() {
    var usernameContainer = $('<div></div>')
        .attr('id', 'usernameContainer');
    var usernameLabel = $('<label>username: </label>');
    var usernameInput = $('<input type="text" />')
        .attr('id', 'username');
    $(usernameContainer).append(usernameLabel, usernameInput);

    $('#container').append(usernameContainer);
}

// why is line 34 ok?
var renderPassword = () => {
    var passwordContainer = $('<div></div>')
        .attr('id', 'passwordContainer');
    var passwordLabel = $('<label>password: </label>');
    $(passwordContainer).append(passwordLabel, passwordInput);

    var passwordInput = $("<input>")
        .attr("type", "password")
        .attr("id", "password")
        .appendTo(passwordContainer);

    $('#container').append(passwordContainer);
}

function renderRegistration() {
    var registerButton = '<button onClick="register()" >register</button>';

    $('#container').append(registerButton);
}

function renderStockButton() {
    $('body')
    .append(
        $('<button>')
        .text('getStockTest')
        .click(getStock)
    );
}

var initializeLoginContainer = function() {
    var container = $('<div>Login</div>')
        .attr('id', 'login-container');
    
    $('body').append(container);

    var username = $('<div>')
        .attr('id', 'login-username');
    
    var usernameLabel = $('<label>username: </label>');
    var usernameInput = $('<input>')
        .attr('id', 'login-username-input');

    username.append(usernameLabel);
    username.append(usernameInput);

    var password = $('<div>')
        .attr('id', 'login-password');

    var passwordLabel = $('<label>password: </label>');
    var passwordInput = $('<input>')
        .attr('id', 'login-password-input')
        .attr('type', 'password');

    password.append(passwordLabel);
    password.append(passwordInput);
    
    container.append(username);
    container.append(password);

    var login = $('<button>login</button>')
        .attr('onClick', 'loginWithCredentials()');

    $('#login-container').append(login);
}
