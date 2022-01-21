function fromJSONToHTMLTable(input) {
    let html = '<table>\n';
    let records = JSON.parse(input);

    // table headers
    html += header(records[0]);

    // table data
    html += tableData(records);

    html += '</table>';
    console.log(html);

    function header(record) {
        let headerRow = '   <tr>';
        for (const key of Object.keys(record)) {
            headerRow += `<th>${escapse(key)}</th>`;
        }
        headerRow += '</tr>\n';
        return headerRow
    }

    function tableData(records) {
        let result = '';
        for (const record of records) {
            result += '   <tr>';
            for (const val of Object.values(record)) {
                result += `<td>${escapse(val)}</td>`;
            }

            result += '</tr>\n';
        }

        return result;
    }

    function escapse(value) {
        return value.toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

fromJSONToHTMLTable(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
);
console.log("=========");
fromJSONToHTMLTable(`[{"Name":"Pesho",
"Score":4,
" Grade":8},
{"Name":"Gosho",
"Score":5,
" Grade":8},
{"Name":"Angel",
"Score":5.50,
" Grade":10}]`
);