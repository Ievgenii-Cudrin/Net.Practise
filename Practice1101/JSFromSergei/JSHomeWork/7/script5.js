let firstArray = [1,2,3];
let secondArray = [9,6,1];
let thirdArray = [9,5,6,5,4,7];

function getMassInfo() {
    document.getElementById('info1').innerHTML = firstArray + " - " + hasMassFirstOrLastNumberOne(firstArray);
    document.getElementById('info2').innerHTML = secondArray + " - " + hasMassFirstOrLastNumberOne(secondArray);
    document.getElementById('info3').innerHTML = thirdArray + " - " + hasMassFirstOrLastNumberOne(thirdArray);
}

function hasMassFirstOrLastNumberOne(mass) {
    if (mass[0] === 1 || mass[mass.length - 1] === 1) {
        return true;
    }
    else {
        return false;
    }
}

getMassInfo();