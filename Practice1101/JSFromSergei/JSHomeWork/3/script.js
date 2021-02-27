let integer = Math.floor(Math.random() * 19);
function game() {
    let valueFromUser = document.getElementById("number").value;
    let number = parseInt(valueFromUser);
    document.getElementById("number").value = "";
    if (Number.isInteger(number)) {
        if (valueFromUser == integer) {
            document.getElementById('info').innerHTML = "You win!";
        }
        else if (valueFromUser < integer) {
            document.getElementById('info').innerHTML = "Your value is less then number";
        }
        else {
            document.getElementById('info').innerHTML = "Your value is large then number";
        }
    }
    else {
        document.getElementById('info').innerHTML = "Your value is not a number";
    }
}