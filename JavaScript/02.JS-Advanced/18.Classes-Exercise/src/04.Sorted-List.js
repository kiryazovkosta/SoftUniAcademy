function list() {
    class List {
        constructor() {
            this.elements = [];
            this.size = 0;
        }

        add(element) {
            if (typeof element === 'number') {
                this.elements.push(Number(element));
                this.size++;
            }

            this.elements.sort((a,b) => a-b);
            return this;
        }

        remove(index) {
            if (typeof index === 'number' && index >= 0 && index < this.elements.length) {
                this.elements.splice(index, 1);
                this.size--;
            }

            return this;
        }

        get(index) {
            if (typeof index === 'number' && index >= 0 && index < this.elements.length) {
                return this.elements[index];
            }
        }
    }

    let list = new List();
    list.add(5);
    list.add(6);
    list.add(7);
    console.log(list.get(1)); 
    list.remove(1);
    console.log(list.get(1));
    console.log(list.size);
}

list();