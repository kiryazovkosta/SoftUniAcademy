function listProcessor(input) {
    let collection = [];

    function add(val) {
        collection.push(val);
    }

    function remove(val) {
        collection = collection.filter(str => str !== val);
    }

    function print() {
        console.log(collection.join(','));
    }

    const innerObj = {
        add,
        remove,
        print
    };

    input.forEach(el => {
        let [command, val] = el.split(' ');
        switch (command) {
            case 'add':
                innerObj.add(val);
                break;
            case 'remove':
                innerObj.remove (val);
                break;
            case 'print':
                innerObj.print();
                break;
            default:
                break;
        }
    });
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
console.log('============');
listProcessor(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);