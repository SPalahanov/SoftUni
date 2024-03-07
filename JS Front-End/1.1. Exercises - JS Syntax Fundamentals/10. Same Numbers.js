function solve(num) {
    
    let sum = 0;

    let count = 0;

    let lastDigit = num % 10;

    const numAsString = num.toString();
    
    for(let i = 0; i < numAsString.length; i++) {
        let currentDigit = num % 10;

        sum += currentDigit;

        if(currentDigit === lastDigit) {
            count++;
        }

        num /= 10;

        num = Math.floor(num)
    }
    
    if(count === numAsString.length) {
        console.log(true)
    } else {
        console.log(false)
    }

    console.log(sum)
}