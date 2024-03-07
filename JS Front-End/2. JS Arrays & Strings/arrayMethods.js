let cars = ['BMW', 'Audi', 'Mercedes', 'Toyota', 'Honda'];

// Get last item
let lastCar = cars.pop();
console.log(lastCar);
console.log(cars);

// Add last item
cars.push('Peugeot', 'Opel', 'VW');
console.log(cars);
/*
let newLength = cars.push('Peugeot');
console.log(newLength);
*/

// Remove first item
let firstCar = cars.shift();
console.log(firstCar);

// Add first element
cars.unshift(firstCar);
console.log(cars);

// Remove item with splice
let deletedCars = cars.splice(2, 2);
console.log(deletedCars);
console.log(cars);

// Add item to array with splice
cars.splice(2, 0, 'Toyoyta');
console.log(cars);

// Add and remove items with splice
cars.splice(1, 3, 'Toyota', 'Audi');
console.log(cars);

// Reverse aaray
cars.reverse();
console.log(cars);

// Join array as string
let carString = cars.join(", ");
console.log(carString);

// Slice (not splice)
let middelCars = cars.slice(1, 3);
console.log(middelCars);
console.log(cars);

// Create shallow copy
let shallowCopy = cars.slice();
console.log(shallowCopy);

// Slice from middle to end
let endCars = cars.slice(1);
console.log(endCars);

// Check if element exist in array
let isToyotaIncluded = cars.includes('Toyota');
console.log(isToyotaIncluded);
let isMercedesIncluded = cars.includes('Mercedes');
console.log(isMercedesIncluded);

let isToyotaIncludedAfter4 = cars.includes('Toyota', 4);
console.log(isToyotaIncludedAfter4);

// Finde index of element
let toyotaIndex = cars.indexOf('Toyota');
console.log(toyotaIndex);

// If there is no such item in the array
let mercedesIndex = cars.indexOf('Mercedes');
console.log(mercedesIndex);

// Find speciffic element
let element = cars.find(car => car === 'Toyota');
console.log(element);

// Find all indexes of toyotas
let topCar = ['Toyota', 'BMW', 'Toyota', 'Audi'];
let tIndex = topCar.indexOf('Toyota');
while (tIndex >= 0) {
    console.log(tIndex);
    tIndex = topCar.indexOf('Toyota', tIndex + 1);
}

// ForEach
cars.forEach(car => console.log(car));

// Map
let numbers = [1, 2, 3, 4, 5];
let doubleNumbers = numbers.map(num => num * 2);
console.log(numbers);
console.log(doubleNumbers);

// Filter 
let oddNumbers = numbers.filter( num => num % 2 !== 0);
console.log(numbers);
console.log(oddNumbers);

// Reduce?!
let sum = numbers.reduce((sum, number) => sum + number, 0);
console.log(sum);

// Chaining
let doubleOddNumbers = numbers
    .filter(num => num % 2 !== 0)
    .map(num => num * 2)
    .reduce((sum, number) => sum + number, 0);
console.log(doubleOddNumbers);