function classHierarchy() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        changeUnits(value) {
            this.units = value;
        }

        metricConversion(num) {
            if (this.units === 'm') {
                return num /= 10;
            }
            if (this.units === 'mm') {
                return num *= 10;
            }

            return num;
        }

        toString() {
            return `Figures units: ${this.units} Area: ${this.area}`;
         }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this._radius = radius;
        }

        get area() {
            this.radius = this.metricConversion(this._radius);
            return Math.PI * Math.pow(this.radius, 2);
        }

        toString() {
            return `${super.toString()} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this._width = width;
            this._height = height;
        }

        get area() {
            this.width = this.metricConversion(this._width);
            this.height = this.metricConversion(this._height);
            return this.width * this.height;
        }

        toString() {
            return `${super.toString()} - width: ${this.width}, height: ${this.height}`;
        }
    }

    return { Figure, Circle, Rectangle };
}
