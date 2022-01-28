function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let data = JSON.parse(document.querySelector('div#inputs textarea').value);
      let restaurants = [];
      data.forEach(function(r){
         let [name, workersList] = r.split(' - ');
         let restaurant = restaurants.find(r => r.name == name);
         restaurant = setRestaurant(restaurant, name);
         workersList = workersList.split(', ');
         for (const worker of workersList) {
            let [name, salary] = worker.split(' ');
            let workerSalary = {
               name: name,
               salary: Number(salary),
            };
            restaurant.workers.push(workerSalary);
         }

         restaurants.push(restaurant);
      });

      let max = findApartmentWithMaximumAverageSalary(restaurants);
      setmaxRestaurantOutput(max);
   }

   function findApartmentWithMaximumAverageSalary(restaurants) {
      let maxRestaurant = undefined;
      let maxAverageSalary = Number.MIN_SAFE_INTEGER;
      for (const restaurant of restaurants) {
         if (restaurant.avgSalary() > maxAverageSalary) {
            maxRestaurant = restaurant;
         }
      }

      return maxRestaurant;
   }

   function setRestaurant(restaurant, name) {
      if (restaurant == undefined) {
         restaurant = {
            name: name,
            workers: [],
            avgSalary: function () {
               let sum = this.workers.reduce((s, a) => s += a.salary, 0);
               return (sum / this.workers.length) || 0;
            },
            bestSalary: function () {
               let max = Number.MIN_SAFE_INTEGER;
               this.workers.forEach(function(w){
                  if (w.salary > max) {
                     max = w.salary;
                  }
               });
               return max;
            }
         };
      }
      return restaurant;
   }

   function setmaxRestaurantOutput(restaurant){
      let message = `Name: ${restaurant.name} Average Salary: ${restaurant.avgSalary().toFixed(2)} Best Salary: ${restaurant.bestSalary().toFixed(2)}`;
      document.querySelector('div#bestRestaurant p').textContent = message;
      message = '';
      for (const worker of restaurant.workers.sort((a,b) => b.salary - a.salary)) {
         message += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }
      document.querySelector('div#workers p').textContent = message.trimEnd();
   }
}