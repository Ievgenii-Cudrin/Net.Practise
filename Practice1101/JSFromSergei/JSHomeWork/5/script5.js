function game() {
    let valueFromUser = document.getElementById("number").value;
    document.getElementById("number").value = "";
    if (valueFromUser === "") {
        document.getElementById('info').innerHTML = "";
    }
    else if (valueFromUser.startsWith('Ру')) {
            document.getElementById('info').innerHTML = valueFromUser;
        }
    else {
        document.getElementById('info').innerHTML = "Ру" + valueFromUser;
    }
}