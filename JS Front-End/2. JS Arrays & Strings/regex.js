let text = 'I am JavaScript developer, JavaScript is awesome!'

//RegExp literal
let pattern = /(java)Script/ig;

//RegExp function constructor
let pattern2 = new RegExp('JavaScript', 'ig');

// Test pattern
console.log(pattern.test(text));

// Match by pattern
console.log(pattern2.exec(text));
console.log(pattern2.exec(text));3

// String regex methods
console.log(text.match(pattern));
console.log('-----------------');
const matches = text.matchAll(pattern);

for (const match of matches) {
    console.log(match);
}
