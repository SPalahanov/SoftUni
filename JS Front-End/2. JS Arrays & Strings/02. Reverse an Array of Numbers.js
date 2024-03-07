function solve(n, numbers) {
    let arr = [];
    for (let i = 0; i < n; i++) {
        arr.push(numbers[i]);
    }

    let output = '';
    for (let i = arr.length - 1; i >= 0; i--) {
        output += arr[i] + ' ';
    }

    console.log(output.trimEnd());
}