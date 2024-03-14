function solve(number) {
    const oddSum = calculateDigitsSum(number, x => x % 2 === 1);
    const evenSum = calculateDigitsSum(number, x => x % 2 === 0);

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);

    function calculateDigitsSum(number, filter) {
    
    
        const digits = number
            .toString()
            .split('')
            .map(digits => Number(digits))
            .filter(filter);
    
        const sum = digits.reduce((acc, digits) => acc + digits, 0)
    
        return sum;
    }
}