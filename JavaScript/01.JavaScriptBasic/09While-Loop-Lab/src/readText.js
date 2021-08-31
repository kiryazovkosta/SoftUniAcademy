function read(params) {
    let index = 0;
    while (params[index] !== "Stop") {
        console.log(params[index]);
        index++;   
    }
}

read(["Nakov",
"SoftUni",
"Sofia",
"Bulgaria",
"SomeText",
"Stop",
"AfterStop",
"Europe",
"HelloWorld"]);

read(["Sofia",
"Berlin",
"Moscow",
"Athens",
"Madrid",
"London",
"Paris",
"Stop",
"AfterStop"]);