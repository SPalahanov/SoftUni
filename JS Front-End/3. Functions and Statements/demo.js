// Function declaration
function log(text) {                //Statemant
    console.log(text);
}

// Function expression
 const log2 = function logTwo() {      //Expression
    console.log('Some text 2');
}

// Arrow function
const log3 = () => console.log('Some text 3');

// Function invokation
log('Some text');
log2();
log3();

// Default return value
const defaultReturnValue = log('Default Value');
console.log(defaultReturnValue);

//Invoke function from another function
function masterLog(text) {
    log(`1 - ${text}`);
    log(`2 - ${text}`);
    log(`3 - ${text}`);
}

masterLog('Ivo');

// Recursion
function countDown(x) {
    if (x > 0) {
        console.log(x);
        
        countDown(x - 1);
    }
}

countDown(10);