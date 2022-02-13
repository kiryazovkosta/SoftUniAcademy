'use strict';

function Person(firstName, lastName) {

    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', {
        get: () => {
            return `${this.firstName} ${this.lastName}`;
        },
        set: (value) => {
            let names = value.split(' ');
            if (names.length != 2) {
                throw new Error(`Full name must be in format [FirstName] [LastName]`);
            }

            this.firstName = names[0];
            this.lastName = names[1];
        }
    });

    return this;
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla

person = new Person("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson
person.fullName = "Peter";
console.log(person.firstName);  // Simon
console.log(person.lastName);  // Simpson
