let firstArray = [3, 6, -2, -5, 7, 3];

function getMassInfo() {
    document.getElementById('info1').innerHTML = multiplicationOfNumbers(firstArray);
}

function multiplicationOfNumbers(array) {
    let arrayWithMultiplication = new Array();

    for (let i = 0; i < array.length; i++) {
        for (let j = 0; j < array.length; j++) {
            if (i !== j) {
                arrayWithMultiplication.push(array[i] * array[j]);
            }
        }
    }

    return Math.max.apply(Math, arrayWithMultiplication);
}

getMassInfo();