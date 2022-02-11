function solution() {
    let text = '';

    function append(value) {
        text += value;
    }

    function removeStart(size){
        text = text.slice(size);
    }

    function removeEnd(size){
        text = text.slice(0, -size);
    }

    function print(){
        console.log(text);
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
