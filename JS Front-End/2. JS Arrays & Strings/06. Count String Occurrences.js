function solve(text, word) {
    let result = text
        .split(' ')
        .filter(w => w === word)
        .length;
    
    console.log(result);
}

solve('This is a word and it also is a sentence', 'is')