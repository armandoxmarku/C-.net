var likes = [0, 0, 0]
var userLike = [
    document.querySelector("#post1Likes"),
    document.querySelector("#post2Likes"),
    document.querySelector("#post3Likes"),
]

function addLike(id) {
    likes[id]++
    if(likes[id]==1){
        userLike[id].innerText = likes[id] +" likes"
    }
    else {
        userLike[id].innerText =likes[id]+" likes"
    }

}