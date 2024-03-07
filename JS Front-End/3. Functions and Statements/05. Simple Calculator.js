function solve(num1, num2, operation) {
    const result = getOperation(num1, num2, operation);

    console.log(result);

    function getOperation(num1, num2, operation) {
        switch (operation) {
            case 'multiply':
                return num1 * num2;
            case 'divide':
                return num1 / num2;
            case 'add':
                return num1 + num2;
            case 'subtract':
                return num1 - num2;
        }
    }
}

solve(50, 13, 'subtract');
solve(40,  8, 'divide');

