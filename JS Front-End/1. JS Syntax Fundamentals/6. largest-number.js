function solve (first, second, third) {
    let largestNumber = Number.MIN_SAFE_INTEGER;

    if (first > second && first > third) {
        largestNumber = first;
    } else if (second > third) {
        largestNumber = second;
    } else {
        largestNumber = third;
    }

    console.log(`The largest number is ${largestNumber}.`);
}