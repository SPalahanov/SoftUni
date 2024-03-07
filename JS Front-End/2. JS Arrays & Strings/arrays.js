// Declare an array
let numbers = [1, 2, 3, 4, 5, 6];
let names = ['Stoyan', 'Pesho', 'Gosho'];

// Declare an empty array
let empty = [];  //truthy value

// Change array by refference
numbers[0] = 10;
console.log(numbers);

// Dynamically add elements to an array
console.log(empty);
empty[0] = 1;
empty[1] = 2;
console.log(empty);

// Accessing by index
let firstName = names[0];
let lastName = names[names.length - 1];

console.log(firstName);
console.log(lastName);

// Accesing invalid inde
console.log(names[3]);
console.log(names[-1]);

// Array destructuring assignment
let [firstNumber, secondNumber, thirdNumber, ...restNumbers] = numbers;
console.log(firstNumber);
console.log(secondNumber);
console.log(thirdNumber);
console.log(restNumbers);

// For of loop
for (let name of names) {
    console.log(name);
}

// rray hack 1
names[10] = 'Stamat';
names[5] = 'Slavi';
console.log(names.length);
console.log(names);

// Array hack 2
let arr = [1, 2, 3];
console.log(arr.length);
arr.length = 10;
console.log(arr);
arr.length = 2;
console.log(arr);