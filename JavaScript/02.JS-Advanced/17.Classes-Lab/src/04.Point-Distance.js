class Point {
    constructor(x,y){
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2){
        let x = Math.abs(p2.x-p1.x);
        let y = Math.abs(p2.y-p1.y);
        return Math.sqrt(x ** 2 + y ** 2);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
