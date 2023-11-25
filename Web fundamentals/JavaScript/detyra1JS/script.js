function message() {
    alert("Ninja was liked");
}

function login(element) {
    if(element.innerText == "logout") {
        element.innerText = "login";
    } else {
        element.innerText = "logout";
    }
}

function hide(element2) {
    element2.remove();
}