function addRemove(commands){
    let numbers = [];
    let number = 1;
    for (const command of commands) {
        if (command === 'add') {
            numbers.push(number);
        } else if (command === 'remove') {
            numbers.pop();
        }

        number++;
    }

    console.log(numbers.length > 0 ? numbers.join('\n') : 'Empty');
}

addRemove(['add', 'add', 'add', 'add']);
console.log('---');
addRemove(['add', 'add', 'remove', 'add', 'add']);
console.log('---');
addRemove(['remove', 'remove', 'remove']);