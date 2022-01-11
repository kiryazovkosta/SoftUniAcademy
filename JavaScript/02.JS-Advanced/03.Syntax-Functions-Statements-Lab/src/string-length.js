function strlen(a, b , c) {
    let length = a.length + b.length + c.length;
    let size = Math.floor(length / 3);

    console.log(length);
    console.log(size);
}

strlen('chocolate', 'ice cream', 'cake');
strlen('pasta', '5', '22.3');