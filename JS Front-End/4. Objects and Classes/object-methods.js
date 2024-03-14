// Define method in object literal with function expression
const cat = {
    name: 'Namvcho',
    breed: 'Persian',
    age: 9,
    grades: [5, 6, 5, 6, 5],
    owner: {
        name: 'Ivo',
        age: 24,
    },
    // Function expression value
    makeSound: function() {
        console.log('Meao...');
    },
    // Arrow function
    sleep: () => console.log('zzzZZzzz'),
}

// Call method
cat.makeSound();

cat['makeSound']();

let methodName = 'makeSound';
cat[methodName]();

// Add method dynamically
cat.eat = function() {
    console.log('Omnomnomnom.....');
}

cat.eat2 = () => console.log('Omnomnomnom.....');

cat.eat();
cat.eat2();

// Use method notation syntax
const dog = {
    name: 'Sharo',
    breed: 'Ulichna Prehyzhodna',
    makeSound() {
        console.log('Wof wof ...');
    },
    ownerName: 'Pehso',
}

// Get all propertie names of an object
const properyNames = Object.keys(cat);
console.log(properyNames);

// Get all propertie names of an object
const properyValues = Object.values(cat);
console.log(properyValues);

// Get object key value pairs
const simpleObject = {
    name: 'Pesho',
    age: 20,
}
const entries = Object.entries(simpleObject);
console.log(entries);

// Reverse entries
const originalSimpleObject = Object.fromEntries(entries);
console.log(originalSimpleObject);
