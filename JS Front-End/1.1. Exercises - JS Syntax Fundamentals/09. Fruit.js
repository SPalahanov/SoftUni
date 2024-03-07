function solve(fruitType, grams, pricePerKilo) {
    const kilograms = grams / 1000;

    const totalPrice = kilograms * pricePerKilo

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruitType}.`)
}