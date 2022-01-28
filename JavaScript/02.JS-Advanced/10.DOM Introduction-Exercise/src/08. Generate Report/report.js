function generateReport() {
    let headers = {};
    
    let headersList = Array.from(document.querySelectorAll("input[type='checkbox']"));
    for (let i = 0; i < headersList.length; i++) {
        const checkbox = headersList[i];
        if (checkbox.checked == true) {
            headers[i] = checkbox.name;
        }
    }

    let records = [];
    let keys = Object.keys(headers).map(k => Number(k)).sort((a,b) => a - b);
    let rowsList = Array.from(document.querySelectorAll("table tbody tr"));
    for (let i = 0; i < rowsList.length; i++) {
        let record = {};
        const row = rowsList[i];
        let cells = Array.from(row.querySelectorAll('td'));
        for (const key of keys) {
            record[headers[key]] = cells[key].textContent;
        }

        records.push(record);
    }

    document.querySelector('div textarea#output').value = JSON.stringify(records);
}