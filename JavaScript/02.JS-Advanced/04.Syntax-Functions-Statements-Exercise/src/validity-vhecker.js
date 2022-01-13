function validity(x1, y1, x2, y2){

    function check(x1, y1, x2, y2){
        let x = x2 - x1;
        let y = y2 - y1;
        let distance = Math.sqrt( (x**2) + (y**2) );
        let status = Number.isInteger(distance) === true ? 'valid' : 'invalid';
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status}`);
    }

    check(x1, y1, 0, 0);
    check(x2, y2, 0, 0);
    check(x1, y1, x2, y2);
}

validity(3, 0, 0, 4);
validity(2, 1, 1, 1);