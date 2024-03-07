let text = 'I am JavaScript developer';

// indexOf
let indexOfJava = text.indexOf('Java');
console.log(indexOfJava);

// Substring
let theBestLanguage = text.substring(indexOfJava, 15)
console.log(theBestLanguage);

// Replace
let csharp = text.replace('JavaScript', 'C#')
console.log(csharp);

// ReplaceAll
let text2 = 'I am JavaScript developer, JavaScript';
let allCsharp = text2.replaceAll('JavaScript', 'C#')
console.log(allCsharp);

// Includes
console.log(text.includes('JavaScript'));

// Repeat
console.log('Tro' + 'lo'.repeat(10));

// Check string start and end
console.log(text.startsWith('I am'));

// Pad string
console.log('10'.padStart(8, '0'));
console.log('10101'.padStart(8, '0'));
console.log('10111010'.padStart(8, '0'));

// Reverse string
let reversedString = text
    .split('')
    .reverse()
    .join('')
console.log(reversedString);