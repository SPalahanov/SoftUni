// Create an object
let person = { name: 'Pesho', age: 20 };
console.log(person);

// Create an object with non classic identifier
let person2 = { 'full-Name': 'Ivan Ivanov' };
console.log(person2);

// Use dot syntax to get property value
console.log(person.name);

// Use bracket syntax to get property value
console.log(person['age']);
console.log(person['full-name']);

// Create an empty object and dynamically add values
let animal = {};

// Add with dot syntax
animal.name = 'Navcho';

// Add with bracket syntax
animal['min-weght'] = 2;

// Add dynamic name property
let propName = 'type';
animal[propName] = 'cat';

console.log(animal);

// Add dynamic name property in the literal
const dynamicPropName = 'fullName';
const person3 = { 
    [dynamicPropName]: 'Ivan Ivanov'
};

console.log(person3);

// Multiline object literal (over 2 properties)
let firstName = 'Ivo';
let lastName = 'Papazov';
let age = 24;

const personInfo = { 
    firstName: firstName,
    lastName: lastName,
    age: age,
};

// Object literal with shorthand syntax
const shortPersonInfo = { 
    firstName,
    lastName,
    age,
};

// Get undefined property
console.log(animal.nonExistent);

// Delete entry
delete shortPersonInfo.firstName;

console.log(shortPersonInfo);