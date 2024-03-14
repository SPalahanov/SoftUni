function solve(firstName, lastName, hairColor) {
    const info = {
        name: firstName,
        lastName,
        hairColor,
    }
    
    const data = JSON.stringify(info);

    console.log(data);
}

solve('George', 'Jones',

'Brown')