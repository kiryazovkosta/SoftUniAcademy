function aggregate(elements) {
    let sum1 = 0;
    let sum2 = 0;
    let sum3 = "";
    
    for (let index = 0; index < elements.length; index++) {
        const element = elements[index];
        sum1 += element;
        sum2 += 1/element;
        sum3 += element;
    }

    console.log(sum1);
    console.log(sum2);
    console.log(sum3);
}

aggregate([1, 2, 3]);
aggregate([2, 4, 8, 16]);