class LibraryCollection {
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.books = [];
    }

    addBook (bookName, bookAuthor) {
        if (this.books.length >= this.capacity) {
            throw new Error('Not enough space in the collection.');
        }

        this.books.push({bookName, bookAuthor, payed: false});
        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName) {
        let book = this.books.find(b => b.bookName == bookName);
        if (!book) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (book.payed == true) {
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;
        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let book = this.books.find(b => b.bookName == bookName);
        if (!book) {
            throw new Error(`The book, you're looking for, is not found.`);
        }

        if (book.payed == false) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books = this.books.filter(b => b.bookName != bookName);
        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let result = [];
        if (typeof bookAuthor === 'undefined') {
            let emptySlots = this.capacity - this.books.length;
            result.push(`The book collection has ${emptySlots} empty spots left.`);
            this.books.sort((a,b) => a.bookName.localeCompare(b.bookName));
            for (const book of this.books) {
                let status = book.payed == true ? 'Has Paid' : 'Not Paid';
                result.push(`${book.bookName} == ${book.bookAuthor} - ${status}.`);
            }

            return result.join('\n');

        } else {
            let authorBooks = this.books.filter(b => b.bookAuthor == bookAuthor);
            if (authorBooks.length > 0) {
                for (const book of authorBooks) {
                    let status = book.payed == true ? 'Has Paid' : 'Not Paid';
                    result.push(`${book.bookName} == ${book.bookAuthor} - ${status}.`);
                }

                return result.join('\n');
            } else {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }
        }
    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());