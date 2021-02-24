let firstArray = [7, 9, 0, -2];

function getMassInfo() {
    document.getElementById('info1').innerHTML = combine(["Ivanov", "Ivan", "Ivanovich"], "***");
}

function combine(array, str) {
    return array.join(str);
}

getMassInfo();