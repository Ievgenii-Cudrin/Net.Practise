function getMassInfo() {
    document.getElementById('info1').innerHTML = square(1);
    document.getElementById('info2').innerHTML = square(2);
    document.getElementById('info3').innerHTML = square(3);
    document.getElementById('info4').innerHTML = square(4);
    document.getElementById('info5').innerHTML = square(5);
    document.getElementById('info6').innerHTML = square(6);
    document.getElementById('info7').innerHTML = square(7);
    document.getElementById('info8').innerHTML = square(8);
    document.getElementById('info9').innerHTML = square(9);
}

function square(integer) {
    let result = 0;
    for (let i = 0; i <= integer; i++) {
        let newInt = 4 * i;
        result = result + newInt;
    }

    return result + 1;
}

getMassInfo();
