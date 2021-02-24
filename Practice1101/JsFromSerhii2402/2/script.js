class Shape {

    constructor(name) {
        this.name = name;
    }

    area = function () {
    }

}

class Square extends Shape {
    constructor(name, length) {
        super(name);
        this.length = length;
    }

    area = function () {
        return this.length * this.length;
    }

    getSquareName = function () {
        return this.name
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
let firstSquare = new Square("firstSquare", 4);


document.getElementById('circleProp').innerHTML = Object.getOwnPropertyNames(firstCircle);
document.getElementById('squareProp').innerHTML = Object.getOwnPropertyNames(firstSquare);