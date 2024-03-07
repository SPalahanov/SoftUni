function solve (firstNUmber, lastNumber) {
    let sum = 0;
    let numbers = '';
    
    for (let i = firstNUmber; i <= lastNumber; i++) {
        sum += i;
        numbers += i + ' ';
    }

    console.log(numbers.trimEnd())
    console.log(`Sum: ${sum}`)
}