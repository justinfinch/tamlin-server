$(document).ready(function () {
    login();
});

//Functions
function login() {
    $('.button-login').click(function () {
        window.location = '/ShopFloor.html';
    });
};

function goToPage(url) {
    window.location = url;
};