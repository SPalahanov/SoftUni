function solve(wordsInput, template) {

    const words = wordsInput.split(', ');
    let startIndex = -1;
    let endIndex = -1;

    for (let i = 0; i < template.length; i++) {
        if (template[i] === '*') {
            if (startIndex < 0) {
                startIndex = i;
                endIndex = i + 1;
            } else {
                endIndex = i + 1;
            }
        } else {
            if (startIndex >= 0) {
                let length = endIndex - startIndex;
                let word = words.find(w => w.length === length)
                template = template.replace('*'.repeat(length), word);
                startIndex = -1;
                endIndex = -1;
            }
        }
    } 

    if (startIndex >= 0) {
        let length = endIndex - startIndex;
        let word = words.find(w => w.length === length)
        template = template.replace('*'.repeat(length), word);
        
    }

    console.log(template);
}

function solve2(wordsInput, template = '') {

    const words = wordsInput.split(', ');
    const matches = template.matchAll(/\*+/g);
    for (const match of matches) {
        const word = words.find(w => w.length === match[0].length)
        template = template.replace(match[0], word)
    }

    console.log(template);
}

function solve3(wordsInput, template = '') {

    const words = wordsInput.split(', ');
    const templateWords = template.split(' ');

    const result = templateWords
        .map(tWord => tWord[0] === '*' 
            ? words.find(w =>w.length === tWord.length) 
            : tWord)
        .join(' ');

    console.log(result);
}

solve('great, learning', 'softuni is ***** place for ******** new programming languages')
solve2('great, learning', 'softuni is ***** place for ******** new programming languages')
solve3('great, learning', 'softuni is ***** place for ******** new programming languages')