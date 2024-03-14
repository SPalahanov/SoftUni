function solve(firstCharacter, secondCharecter) {
    const [start, end] = getSortedCharacters(firstCharacter, secondCharecter)

    const result = getCharacterBetween(start, end);

    console.log(result.join(' '));
}

function getSortedCharacters(a, b) {
    const characters = [a, b];
    
    characters.sort();

    return characters
}

function getCharacterBetween(start, end) {
    let characters = [];
    
    for (let i = start.charCodeAt(0) + 1; i < end.charCodeAt(0); i++) {
        characters.push(String.fromCharCode(i))
    }

    return characters
}