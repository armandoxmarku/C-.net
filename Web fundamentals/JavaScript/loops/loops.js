for (var index = 1; index < 21; index++) {
    console.log(index)
    
}

for (var index = 1; index < 101; index++) {
    if(index % 3===0){
        console.log(index)
    }
    
    
}

var sequence = [4, 2.5, 1, -0.5, -2, -3.5];

for (var i = 0; i < sequence.length; i++) {
    console.log(sequence[i]);
}

var sum = 0;
for (var i = 1; i < 101; i++) {
    sum += i
    console.log(`Adding ${i}: Current sum is ${sum}`)
    
}

var product = 1;
for (var i = 1; i < 13; i++) {
    product *= i
    
    console.log(`Adding ${i}: Current sum is ${product}`)
    
}
