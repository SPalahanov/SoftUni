function solve(number) {
    const divisors = getDivisors(number);

    const sum = divisors.reduce((a, b) => a + b, 0);

    if(sum === number) {
        console.log('We have a perfect number!');
    } else {
        console.log('It\'s not so perfect.');
    }

    function getDivisors(number) {
        const divisiors = [];
    
        for (let i = number / 2; i >= 0; i--) {
            if (number % i === 0) {
                divisiors.push(i)
            }
        }
    
        return divisiors
    }
}

solve(6)
solve(1236498)