const url = 'http://localhost:3030/jsonstore/collections/students';

window.onload = async function() {
    const formElement = document.getElementById('form');
    formElement.addEventListener('submit', await submitForm);

    const resultElement = document.querySelector('table#results tbody');

    const students =  await getStudents();
    populateTableWithStudents(students);

    async function submitForm(event) {
        event.preventDefault();
        const data = new FormData(formElement);

        const firstName = data.get('firstName');
        const lastName = data.get('lastName');
        const facultyNumber = data.get('facultyNumber');
        const grade = data.get('grade');

        if (firstName != '' && lastName != '' && facultyNumber != '' 
            && /^\d+$/.test(facultyNumber) && grade != '' && !isNaN(grade)) {
            try {
                const request = await fetch(url, {
                    method: 'post',
                    headers: {
                        'content-type': 'application/json'
                    },
                    body: JSON.stringify({
                        firstName,
                        lastName,
                        facultyNumber,
                        grade
                    })
                });
                const record = await request.json();
                resultElement.appendChild(createRow(record));
                clearForm();

            } catch (error) {
                alert(error.message);
            }
        }
    }

    function populateTableWithStudents(students) {
        students.forEach(student => resultElement.appendChild(createRow(student)));
    }
};

async function getStudents() {
    const res = await fetch(url);
    const data = await res.json();
    return Object.values(data);
}

function createRow(record) {
    let tr = document.createElement('tr');
    let td1 = document.createElement('td');
    td1.textContent = record.firstName;
    let td2 = document.createElement('td');
    td2.textContent = record.lastName;
    let td3 = document.createElement('td');
    td3.textContent = record.facultyNumber;
    let td4 = document.createElement('td');
    td4.textContent = record.grade;
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tr.appendChild(td4);
    return tr;
}

function clearForm() {
    document.querySelectorAll('input[type="text"]').forEach(el => el.value = '');
}