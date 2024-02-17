function pushFront(arr, val) {
    for (let i = arr.length; i > 0; i--) {
        arr[i] = arr[i - 1];
    }
    arr[0] = val;
    return arr;
}

function popFront(arr) {
    const first = arr[0];
    for (let i = 0; i < arr.length - 1; i++) {
        arr[i] = arr[i + 1];
    }
    arr.length = arr.length - 1;
    console.log(first + " returned, with " + arr + " printed in the function");
    return first;
}

function insertAt(arr, index, val) {
    for (let i = arr.length; i > index; i--) {
        arr[i] = arr[i - 1];
    }
    arr[index] = val;
    return arr;
}

function removeAt(arr, index) {
    const removed = arr[index];
    for (let i = index; i < arr.length - 1; i++) {
        arr[i] = arr[i + 1];
    }
    arr.length = arr.length - 1;
    console.log(removed + " returned, with " + arr + " printed in the function");
    return removed;
}

function swapPairs(arr) {
    for (let i = 0; i < arr.length - 1; i += 2) {
        const temp = arr[i];
        arr[i] = arr[i + 1];
        arr[i + 1] = temp;
    }
    return arr;
}

function removeDupes(arr) {
    const result = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] !== arr[i + 1]) {
            result.push(arr[i]);
        }
    }
    return result;
}

// Testing
console.log(pushFront([5, 7, 2, 3], 8)); 
console.log(pushFront([99], 7)); 
console.log(popFront([0, 5, 10, 15])); 
console.log(popFront([4, 5, 7, 9])); 
console.log(insertAt([100, 200, 5], 2, 311)); 
console.log(insertAt([9, 33, 7], 1, 42)); 
console.log(removeAt([1000, 3, 204, 77], 1));
console.log(removeAt([8, 20, 55, 44, 98], 3)); 
console.log(swapPairs([1, 2, 3, 4])); 
console.log(swapPairs(["Brendan", true, 42])); 
console.log(removeDupes([-2, -2, 3.14, 5, 5, 10])); 
console.log(removeDupes([9, 19, 19, 19, 19, 19, 29])); 
