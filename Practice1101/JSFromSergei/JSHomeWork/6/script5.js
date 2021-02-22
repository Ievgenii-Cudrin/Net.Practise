function getCounutOfChars() {
    let str = document.getElementById("number").value;
    var m = str.match(/[aeiou]/gi);
    document.getElementById('info').innerHTML = m.length;
}