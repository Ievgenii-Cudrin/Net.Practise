function getFullPathLocationFile() {
    console.log(window.location);
    document.getElementById('path').innerHTML = window.location;
}

getFullPathLocationFile();