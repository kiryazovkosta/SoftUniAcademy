function createSortedList(){
    let list = {
        items: [],
        add(element){
            this.items.push(element)
            this.items.sort((a,b) => a - b);
        },
        remove(index){
            if (index >= 0 && index < this.items.length) {
                this.items.splice(index, 1).sort((a,b) => a - b);  
            }
            
        },
        get(index){
            return this.items[index];
        },
        get size() {
            return this.items.length;
        }
    };

    return list;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);
