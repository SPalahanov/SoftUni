function solve(numbers) {
    let oddSum = 0;
    let evenSum = 0;
    
    for (let i = 0; i < numbers.length; i++) {
        
        if(numbers[i] % 2 !==0){
            oddSum += numbers[i];
        } else {
            evenSum += numbers[i];
        }
    }
    console.log(evenSum - oddSum);
}