const myArray = {
    'first': 5,
    'second': 10,
    'third': 15,
};

const keys = Object.keys(myArray);
for (const key in myArray) {
    console.log(key);
}

const values = Object.values(myArray);
for (const value of values) {
    console.log(value);
}

const entrities = Object.entries(myArray);
for (const [key, value] of entrities) {
    console.log(`${key} -> ${value}`);
}

const MyMath = {
    sum(numbers){
        return numbers.reduce((acc, val) => acc + val, 0);
    },
    ascending: (a, b) => Math.max(a,b),
};

console.log(MyMath.sum([1, 2, 3 ,4, 5]));

const x = MyMath.ascending(5, 10);
console.log(x);

let type = 'first';
const parser = {
    first() { console.log('first001') },
    seconsd() {console.log('second')},
    default(){console.log('default')},
};

parser[type]();

