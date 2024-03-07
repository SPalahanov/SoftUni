function solve(input) {

    let array = input.split('');

    let word = '';

    let splitedArray = [];

    for (let i = 0; i < array.length; i++) {
        let count = 0;
        if (array[i].charCodeAt() >= 65 && array[i].charCodeAt() <= 90) {
            if (word.length > 0) {
                splitedArray.push(word)
            }
            word = '';
            word = word + array[i];
            
        } else {
            word = word + array[i];
        }

        if (i === array.length - 1) {
            splitedArray.push(word)
        }
    }

    console.log(splitedArray.join(', '));
}

function lookAhead(input) {

    console.log(input.split(/(?=[A-Z])/).join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');

lookAhead('SplitMeIfYouCanHaHaYouCantOrYouCan');