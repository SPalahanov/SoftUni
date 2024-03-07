function solve(text, word) {
    let index = text.indexOf(word);

    while (index >= 0) {
        text = text.replace(word, '*'.repeat(word.length));

        index = text.indexOf(word);
    }
    
    console.log(text);
}

function solve2(text, word) {
    const pattern = new RegExp(word, 'g');

    const result = text.replace(pattern, '*'.repeat(word.length));

    console.log(result);
}

function solve3(text, word) {
    const result = text.replaceAll(word, '*'.repeat(word.length));

    console.log(result);
}

solve('A small sentence with some words','small')
solve2('Find the hidden word', 'hidden')
solve3('A small sentence with some words','small')