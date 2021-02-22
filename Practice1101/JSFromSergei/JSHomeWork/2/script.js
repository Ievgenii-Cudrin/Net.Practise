function getWeekDay(date) {
    let days = ['ВС', 'ПН', 'ВТ', 'СР', 'ЧТ', 'ПТ', 'СБ'];

    return days[date.getDay()];
}
let year = 2014;
let countOfDays = 0;
function getCountOfDays() {
    for (let i = 2014; i < 2050; i++) { 
        let date = new Date(year, 0, 1);
        var day = getWeekDay(date);
        if (day === 'ВС') {
            countOfDays++;
        }
        year++;
    }

    document.getElementById('countOfDays').innerHTML = countOfDays;
}

getCountOfDays();