let fullName = 'Stamat Petkov';
let fullName2 = 'Gosho Goshev';

let phoneBook = {
    'Ivan Ivanov': '+35988123123',
    'Ginka Stamenova': '+35988123124',
    [fullName]: '+35988123126',
};

phoneBook['Pesho Gerov'] = '+35988123125';
phoneBook[fullName2] = '+35988123127';

console.log(phoneBook);

// Use for in loop
for (const name in phoneBook) {
    console.log(`${name} ->>> ${phoneBook[name]}`);
}


for (const name of Object.keys(phoneBook)) {
    console.log(name);
}