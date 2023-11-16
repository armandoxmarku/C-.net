function message() {
    alert("Ninja was liked");
}

function login(element) {
    if(element.innerText == "Login") {
        element.innerText = "Logout";
    } else {
        element.innerText = "Logout";
    }
}

function hide(element2) {
    element2.remove();
}