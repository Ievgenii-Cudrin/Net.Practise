﻿class Shape {
    yearCreated = "2021";
    name = "Shape";

    area() {
        alert("Area from parrent class!")
    }

}

class Square {
    constructor(length) {
        this.length = length;
    }

    area() {
        return this.length * this.length;
    }
    __proto__ = Shape;
}

class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    area() {
        return 3.14 * this.radius * this.radius;
    }
    __proto__ = Shape;
}

firstCircle = new Circle(3);
firstCircle.name = "firstCircle";
console.log(firstCircle.yearCreated);
firstSquare = new Square(4);
firstSquare.name = "firstSquare";
console.log(firstSquare.yearCreated);

document.getElementById('circle').innerHTML = firstCircle.area();
document.getElementById('square').innerHTML = firstSquare.area();