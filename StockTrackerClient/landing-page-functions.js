function register() {
    var usernameText = $('#username').val();
    var passwordText = $('#password').val();

    var registrationCredentials =
        {
            'userName': usernameText,
            'password': passwordText,
            'confirmPassword': passwordText
        };

    $.post('http://localhost:22447/api/account/register', registrationCredentials);
}

function loginWithCredentials() {
    username = $('#login-username-input').val();
    password = $('#login-password-input').val();

    var credentials = {
        username: username,
        password: password,
        grant_type: 'password'
    };

    $.post('http://localhost:22447/token', credentials, setTokenInfoInSessionStorage)
        .fail(function(error) {
            console.log(error);
        });
}

function setTokenInfoInSessionStorage(tokenInformation) {
    sessionStorage.setItem('token', tokenInformation.access_token);
    sessionStorage.setItem('expiresIn', tokenInformation.expires_in);
    sessionStorage.setItem('tokenType', tokenInformation.token_type);

    setAjaxHeadersWithToken(tokenInformation.access_token);
}

function setAjaxHeadersWithToken(token) {
    $.ajaxSetup({
        beforeSend: function(xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + token);
        }
    });
}

function getStock() {
    $.get('http://localhost:22447/api/stock/72', function(data) {
        console.log(data);
    });
}