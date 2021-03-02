class Shape {

    constructor(name) {
        this.name = name;
    }

    area() {
    }

}

class Square extends Shape {
    constructor(name, length) {
        super(name);
        this.length = length;
    }

    area() {
        return this.length * this.length;
    }
}

class Circle extends Shape {
    constructor(name, radius) {
        super(name);
        this.radius = radius;
    }

    area() {
        return 3.14 * this.radius * this.radius;
    }
}

document.getElementById('circle').innerHTML = new Circle("firstCircle", 3).area();
document.getElementById('square').innerHTML = new Square("firstSquare", 4).area();