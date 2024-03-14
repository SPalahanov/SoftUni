function solve(number) {
    const createRow = (num) => new Array(num).fill(num).join(' ');

    for (let i = 0; i < number; i++) {
        console.log(createRow(number));
    }
}

solve(7);