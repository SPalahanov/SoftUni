let a = 10;
let b = 20;
console.log(a + b);

var c = 30;
a = 5;
console.log(a + c);

const pi = 3.14;

a = 15;
a = 10


if (a <= 10) {
    console.log('a is lower or equal to 10');
} else if (a <= 20) {
    console.log('a is lower than 20');
} else {
    console.log('a is higher than or equal to 20');
}

let first = 4;
let second = 8

// Function declaration
function add(first, second) {
    console.log(first + second)
}

// Function invocation
add(first, second);

grade = 5.78;

// Console print with strng concatenation
function solve (name, grade){
    console.log('This name is: ' + name + ', grade: ' + grade + '.')
}

solve ('Slavi', grade)

// Fix the number output
console.log(grade.toFixed(1))

// String interpolation / template literal
function solve (name, grade){
    console.log(`This name is: ${name}, grade: ${grade}.`)
}

// Single vs double quotes for string
console.log('Pesho');
console.log("Gosho");
console.log("Mr." + 'Pesho'); // Not recommended to mix both
console.log("Gosho: K'vo staa");
console.log('Gosho: K\'vo staa');
console.log('Gosho kaza: "Kvo staa"');


let num = 5.19923
// Rounding vs toFixed
console.log(num.toFixed(3))
console.log(Math.round(num))
console.log(Math.round(5.1))

//Switch statement
const firstName = 'pesho';
switch (firstName) {
    case 'gosho':
        console.log('Zdrasti gosho');
        break;
    case 'pesho':
        console.log('Maraba pesho');
        break;
    default:
        console.log('Koi si ti?')
        break;
}


// Truthy and Falsy Values
if(firstName) {
    console.log('There is pesho')
} else {
    console.log('There is no pesho')
}

//For loop
for (let i = 0; i < 8; i++) {
    console.log(i);
}


//While loop
let i = 0 ;
while(i < 8) {
    console.log(i);
    i++;
}

// Undefined
let futureValue;

console.log(typeof futureValue)