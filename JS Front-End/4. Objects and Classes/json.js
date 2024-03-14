let person = {
    name: 'Pesho',
    age: 20,
}

// Convert JS Object to JSON
const data = JSON.stringify(person);
console.log(data); // It's a string

// Convert JSON Object to JS
const originalObject = JSON.parse(data);
console.log(originalObject);