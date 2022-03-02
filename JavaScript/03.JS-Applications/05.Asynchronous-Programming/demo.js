const {performance} = require('perf_hooks');

const t0 = performance.now();

let calc1 = new Promise(function (resolve, reject) {
    try {
        let sum = 0;
        for (let i = 0; i < 10000000000; i++) {
            const element = i + 1;
            sum += (i * 0.8) - 0.4;
        }
        resolve('1' + sum);
    } catch (error) {
        reject(error.message);
    }
});//.then(out => console.log(out)).catch(err => console.log(err));

console.log('a');

let calc2 = new Promise(function (resolve, reject) {
    try {
        let sum = 0;
        for (let i = 0; i < 100; i++) {
            const element = i + 1;
            sum += (i * 0.8) - 0.4;
        }
        resolve('2' + sum);
    } catch (error) {
        reject(error.message);
    }
});//.then(out => console.log(out)).catch(err => console.log(err));

let calc3 = new Promise(function (resolve, reject) {
    try {
        let sum = 0;
        for (let i = 0; i < 100000000000; i++) {
            const element = i + 1;
            sum += (i * 0.8) - 0.4;
        }
        resolve('3' + sum);
    } catch (error) {
        reject(error.message);
    }
});//.then(out => console.log(out)).catch(err => console.log(err));

let calc4 = new Promise(function (resolve, reject) {
    try {
        let sum = 0;
        for (let i = 0; i < 1000000000; i++) {
            const element = i + 1;
            sum += (i * 0.8) - 0.4;
        }
        resolve('4' + sum);
    } catch (error) {
        reject(error.message);
    }
});//.then(out => console.log(out)).catch(err => console.log(err));

let calc5 = new Promise(function (resolve, reject) {
    try {
        let sum = 0;
        for (let i = 0; i < 1000; i++) {
            const element = i + 1;
            sum += (i * 0.8) - 0.4;
        }
        resolve('5' + sum);
    } catch (error) {
        reject(error.message);
    }
});//.then(out => console.log(out)).catch(err => console.log(err));

Promise.all([calc1, calc2, calc3, calc4, calc5]).then((values) => {
    console.log(values);
  });

const t1 = performance.now();
console.log(`Call to doSomething took ${t1 - t0} milliseconds.`);