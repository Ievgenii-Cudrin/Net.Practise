class Shape {

    constructor(name) {
        this.name = name;
    }

    area = function () {
    }

}

class Circle extends Shape {
    constructor(name, radius) {
        super(name);
        this.radius = radius;
    }

    area = function () {
        return 3.14 * this.radius * this.radius;
    }

    getCircleName = function () {
        return this.name;
    }
}

let firstCircle = new Circle("firstCircle", 3);

let arrayWithKeysValuesForFirstCircle = new Array();

function CreateKeyValuePairsForCircle() {
    for (const [key, value] of Object.entries(firstCircle)) {
        arrayWithKeysValuesForFirstCircle.push(key + " - " + value);
    }
}

CreateKeyValuePairsForCircle();

document.getElementById('circleProp').innerHTML = arrayWithKeysValuesForFirstCircle;
