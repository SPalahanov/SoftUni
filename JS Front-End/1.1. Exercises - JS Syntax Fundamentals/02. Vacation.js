function solve(peopleCount, groupType, dayType) {
    let totalPrice;
    
    if(groupType === 'Students') {
        if(dayType === 'Friday') {
            totalPrice = peopleCount * 8.45;
        } else if(dayType === 'Saturday') {
            totalPrice = peopleCount * 9.8;
        } else if(dayType === 'Sunday') {
            totalPrice = peopleCount * 10.46;
        }

        if(peopleCount >= 30) {
            totalPrice -= totalPrice * 0.15;
        }
    }

    if(groupType === 'Business') {

        if(peopleCount >= 100) {
            peopleCount -= 10;
        }

        if(dayType === 'Friday') {
            totalPrice = peopleCount * 10.9;
        } else if(dayType === 'Saturday') {
            totalPrice = peopleCount * 15.6;
        } else if(dayType === 'Sunday') {
            totalPrice = peopleCount * 16;
        }
    }

    if(groupType === 'Regular') {
        if(dayType === 'Friday') {
            totalPrice = peopleCount * 15;
        } else if(dayType === 'Saturday') {
            totalPrice = peopleCount * 20;
        } else if(dayType === 'Sunday') {
            totalPrice = peopleCount * 22.5;
        }

        if(peopleCount >= 10 && peopleCount <=20) {
            totalPrice -= totalPrice * 0.05;
        }
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`)
}