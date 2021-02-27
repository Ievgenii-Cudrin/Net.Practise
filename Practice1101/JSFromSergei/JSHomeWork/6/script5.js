function getCounutOfChars() {
    let str = document.getElementById("number").value;
    var m = str.match(/[aeiou]/gi);
    const countLetters = Array.from(str).filter(letter => 'aeiou'.includes(letter)).length;
    document.getElementById('info').innerHTML = m.length;
    document.getElementById('info1').innerHTML = countLetters;
}