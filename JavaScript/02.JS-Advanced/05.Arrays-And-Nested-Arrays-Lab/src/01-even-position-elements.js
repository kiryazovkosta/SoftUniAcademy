function even(array) {
    let evenElements = [];
    for (let index = 0; index < array.length; index += 2) {
        const element = array[index];
        evenElements.push(element);
    }

    console.log(evenElements.join(" "));
}

even(['20', '30', '40', '50', '60']);
even(['5', '10']);