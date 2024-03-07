function solve(numOne, numTwo, numThree) {
    if (checkSign(numOne, numTwo, numThree) % 2 === 1) {
        console.log('Negative');
    } else {
        console.log('Positive');
    }

    function checkSign(numOne, numTwo, numThree) {
        let count = 0;
        
        if (numOne < 0) {
            count++;
        }

        if (numTwo < 0) {
            count++;
        }

        if (numThree < 0) {
            count++;
        }

        return count;
    }
}

function fancySolve(a, b, c) {
    const multiply = (a, b) => a * b;

    if(multiply(multiply(a, b), c) >= 0) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}

solve(2, 3, -5)
fancySolve(2, 3, -5)