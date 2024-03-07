function solve(numbers) {
    numbers.sort((a, b) => a - b);

    let newArray = [];

    while (numbers.length > 0) {
        newArray.push(numbers.shift())
        
        if (numbers.length >= 2) {
            newArray.push(numbers.pop())
        }
    }
    
    return newArray;
}