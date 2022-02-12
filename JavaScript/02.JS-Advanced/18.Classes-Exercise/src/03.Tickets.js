function ticketsDatabase(ticketsList, parameter) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = readTickets(ticketsList);
    sortTickets(tickets, parameter);
    return tickets;

    function readTickets(ticketsList) {
        let tickets = [];
        for (const iterator of ticketsList) {
            let [destination, price, status] = iterator.split('|');
            tickets.push(new Ticket(destination, price, status));
        }

        return tickets;
    }

    function sortTickets(tickets, parameter) {
        if (parameter === 'destination') {
            tickets.sort((a, b) => a.destination.localeCompare(b.destination));
        } else if (parameter === 'price') {
            tickets.sort((a, b) => a.price - b.price);
        } else {
            tickets.sort((a, b) => a.status.localeCompare(b.status));
        }
    }
}

ticketsDatabase(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
);

ticketsDatabase(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
);
