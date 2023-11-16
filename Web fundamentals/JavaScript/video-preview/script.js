console.log("page loaded...");

function playVideo(element) {
    element.play();
    element.loop = true;
}

function pauseVideo(element) {
    element.pause();
}