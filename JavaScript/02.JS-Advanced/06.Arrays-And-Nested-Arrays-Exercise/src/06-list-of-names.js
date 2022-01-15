function sortByName(names) {
    names.sort((a, b) => a.localeCompare(b));
    names.forEach((v, i) => console.log(`${i+1}.${v}`));
}

sortByName(["John", "Bob", "Christina", "Ema"]);