function solve(arr, n) {
    let newArr = [];
    
    for (let i = 0; i < arr.length; i += n) {
        newArr.push(arr[i]);
    }

    return newArr;
}

function solve2(arr, n){
    const newArr = arr.filter((element, index) => index % n === 0)

    return newArr;
}