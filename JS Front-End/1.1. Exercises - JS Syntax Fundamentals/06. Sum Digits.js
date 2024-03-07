function solve(numbers) {

    const num = `${numbers}`;

    let sum = 0;

    for(let i = 0; i < num.length; i++) {
        let currentDigit = numbers % 10;

        sum += currentDigit;

        numbers /= 10;

        numbers = Math.floor(numbers)
    }

    console.log(sum)
}