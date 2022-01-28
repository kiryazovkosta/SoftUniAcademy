function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let text = document.getElementById('searchField').value;
      let rows = Array.from(document.querySelectorAll('table tbody tr'));
      rows.forEach(function (row) {
         row.classList.remove('select');
      });

      rows.filter(function (row) {
         return Array.from(row.children).filter(c => c.textContent.includes(text)).length > 0;
      }).forEach(function (row) {
         row.classList.add('select');
      });

      document.getElementById('searchField').value = '';
   }
}