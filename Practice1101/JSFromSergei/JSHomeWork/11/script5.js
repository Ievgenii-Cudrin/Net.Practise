function getMassInfo() {
    document.getElementById('info1').innerHTML = removeDuplicates([1, 1, 2, 3, 4, 3, 2]);
}

function removeDuplicates(array) {
    let arrayWithMultiplication = new Array();
    arrayWithMultiplication.push(array[0]);

    for (let i = 1; i < array.length; i++) {
        let flag = true;
        for (let j = 0; j < arrayWithMultiplication.length; j++) {
            if (arrayWithMultiplication[j] === array[i]) {
                flag = false;
            }
        }
        if (flag) {
            arrayWithMultiplication.push(array[i]);
        }
    }

    return arrayWithMultiplication;
}

getMassInfo();