function sorting(numbers){
    let result = [];
    numbers.sort((a,b) => a - b);
    
    let length = numbers.length;
    for (let i = 0; i < length; i++) {
        if (i % 2 == 0) {
            result.push(numbers.shift());
        }
        else
        {
            result.push(numbers.pop());
        }
    }

    return result;
}

sorting([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);