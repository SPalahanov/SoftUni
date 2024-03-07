function solve(string) {
    let newString = '';

    oldString = string;
    
    for (let i = 0; i < string.length; i++) {
        let newChar = '';

        if(string[i] === ' ') {
            newChar = ", ";
        } else if(string[i] === '.' && (string[i + 1] != ',' || string[i + 1] != '!' || string[i + 1] != '?')) {
             newChar = ", ";
        } else if(string[i] === ',' || string[i] === '!' || string[i] === '?') {
            newChar = '';
        } else {
            let char = string[i].charCodeAt();
            if (char > 90) {
                char -= 32
            }
            newChar = String.fromCharCode(char);
        }

        newString += newChar;
    }
    
    console.log(newString);
}

solve('Hi, how are you?')
solve('Functions in JS can be nested, i.e. hold other functions')