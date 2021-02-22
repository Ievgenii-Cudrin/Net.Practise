function getWeekDay(date) {
    let days = ['ВС', 'ПН', 'ВТ', 'СР', 'ЧТ', 'ПТ', 'СБ'];

    return days[date.getDay()];
}
let year = 2014;
let countOfDays = 0;
function getCountOfDays() {
    let arrayYears = new Array();
    for (let i = 2014; i < 2050; i++) { 
        let date = new Date(year, 0, 1);
        var day = getWeekDay(date);
        if (day === 'ВС') {
            countOfDays++;
            arrayYears.push(date.getFullYear());
        }
        year++;
    }

    document.getElementById('countOfDays').innerHTML = arrayYears;
}

getCountOfDays();