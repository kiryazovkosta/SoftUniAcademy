function solve() {
    let total = 0;
    let salaryElement = document.getElementById('salary');
    let  spanBudget = document.querySelector('span#sum')
    let table = document.querySelector('table')
    let tbody = document.querySelector('tbody#tbody');
    let inputElements= Array.from(document.querySelectorAll('input'));
    let addWorkerButton = document.getElementById('add-worker');

    addWorkerButton.addEventListener('click', add);

    function add(ev ){
        ev.preventDefault();
        for (const element of inputElements) {
            if (element.value == '') {
                return;
            }
        }

        let trElement = document.createElement('tr');
        for (const element of inputElements) {
            let tdElement = document.createElement('td');
            tdElement.textContent = element.value;
            trElement.appendChild(tdElement);
        }

        let tdButtonsElement = document.createElement('td');
        let firedButton = document.createElement('button');
        firedButton.className = 'fired';
        firedButton.textContent = 'Fired';
        firedButton.addEventListener('click', fired);
        let editButton = document.createElement('button');
        editButton.className = 'edit';
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', edit);

        tdButtonsElement.appendChild(firedButton);
        tdButtonsElement.appendChild(editButton);
        trElement.appendChild(tdButtonsElement);
        tbody.appendChild(trElement);

        let salary = Number(salaryElement.value);
        total += salary;
        spanBudget.textContent = total.toFixed(2);

        for (const element of inputElements) {
            element.value = '';
        }

        function edit(ev) {
            for (let i = 0; i < inputElements.length; i++) {
                inputElements[i].value = trElement.children[i].textContent;
            }

            let val = Number(trElement.children[5].textContent);
            total -= val;
            spanBudget.textContent = total.toFixed(2);
            ev.target.parentElement.parentElement.remove();
        }
    
        function fired(ev) {
            let val = Number(trElement.children[5].textContent);
            total -= val;
            spanBudget.textContent = total.toFixed(2);
            ev.target.parentElement.parentElement.remove();
        }
    }




}

solve()