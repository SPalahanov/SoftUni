function solve(numbers, n) {
    for (let i = 0; i < n; i++) {
        let currentNum = numbers.shift();
        numbers.push(currentNum)
    }

    console.log(numbers.join(' '));
}

function solve2(numbers, rotations) {
    for (let i = 0; i < rotations; i++) {
        let firstNumber = numbers[0];
        let rotatedNumbers = [];
        for (let j = 1; j < numbers.length; j++) {
            rotatedNumbers[j - 1] = numbers[j];
        }

        rotatedNumbers[rotatedNumbers.length] = firstNumber;
        numbers = rotatedNumbers;
    }   

    console.log(numbers.join(' '));
}

solve([51, 47, 32, 61, 21], 2)
solve2([32, 21, 61, 1], 4)