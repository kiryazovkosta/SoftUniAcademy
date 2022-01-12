function area(radius) {
    let radiusType = typeof(radius);
    if (radiusType === "number") {
        let result = radius ** 2 * Math.PI;
        console.log(result.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${radiusType}.`);
    }
}

area(5);
area('name');
area(undefined);