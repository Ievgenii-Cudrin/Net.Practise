let firstArray = [1, 2, 3];
let secondArray = [9, 6, 1];
let thirdArray = [9, 5, 6, 5, 4, 7];

function getMassInfo() {
    document.getElementById('info1').innerHTML = last([7, 9, 0, -2], 0);
    document.getElementById('info2').innerHTML = last([7, 9, 0, -2], 3);
    document.getElementById('info3').innerHTML = last([7, 9, 0, -2], 6);
        
}

function last(mass, count) {
    if (count === 0) {
        return "";
    }
    else if (mass.length <= count) {
        return mass;
    }
    else {
        let newArray = new Array();
        let index;
        let difference = mass.length - count;

        for (let i = difference; i < mass.length; i++) {
            index = i;
            newArray[index - difference] = mass[index];
        }

        return newArray;
    }
}

getMassInfo();