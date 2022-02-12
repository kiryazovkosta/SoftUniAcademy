function work() {
    class Company {
        constructor() {
            this.departments = {}
        }

        addEmployee(name, salary, position, department) {
            if (this.isInvalid(name)
                || this.isInvalid(salary)
                || this.isInvalid(position)
                || this.isInvalid(department)) {
                throw new Error('Invalid input!');
            }

            if (!this.departments.hasOwnProperty(department)) {
                this.departments[department] = [];
            }

            this.departments[department].push({
                name, 
                salary, 
                position
            });

            return `New employee is hired. Name: ${name}. Position: ${position}`;
        }

        bestDepartment(){
            let bestDepartment = '';
            let bestSalary = 0;
            for (const [key, value] of Object.entries(this.departments)) {
                let averageSalary = value.reduce((acc, c) => acc + c.salary, 0) / value.length;
                if (averageSalary > bestSalary) {
                    bestDepartment = key;
                    bestSalary = averageSalary;
                }
            }

            let result = [];
            result.push(`Best Department is: ${bestDepartment}`);
            result.push(`Average salary: ${bestSalary.toFixed(2)}`);
            this.departments[bestDepartment].sort((a,b) => {
                if (b.salary < a.salary) {
                    return -1;
                }
                if (b.salary > a.salary) {
                    return 1;
                }

                return a.name.localeCompare(b.name);
            });

            for (const worker of this.departments[bestDepartment]) {
                result.push(`${worker.name} ${worker.salary} ${worker.position}`);
            }

            return result.join('\n');
        }


        isInvalid(argument) {
            if (argument === null || argument === undefined || argument === '') {
                return true;
            }

            if (typeof argument === 'number' && argument < 0) {
                return true;
            }

            return false;
        }
    }


    let c = new Company();
    c.addEmployee("Stanimir", 2000, "engineer", "Construction");
    c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
    c.addEmployee("Slavi", 500, "dyer", "Construction");
    c.addEmployee("Stan", 2000, "architect", "Construction");
    c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
    c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
    c.addEmployee("Gosho", 1350, "HR", "Human resources");
    console.log(c.bestDepartment());

}

work();