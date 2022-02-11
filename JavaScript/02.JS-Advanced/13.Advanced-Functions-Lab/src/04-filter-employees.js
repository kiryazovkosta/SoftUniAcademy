function solve(empl, criteria){
    let employess = JSON.parse(empl);
    if (criteria === 'all') {
        employess.forEach((v,i) => console.log(`${i}. ${v.first_name} ${v.last_name} - ${v.email}`));
    } else {
        let [prop, pattern] = criteria.split('-');
        employess.filter(e => e[prop] === pattern).forEach((v,i) => console.log(`${i}. ${v.first_name} ${v.last_name} - ${v.email}`));
    }
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'all'
);