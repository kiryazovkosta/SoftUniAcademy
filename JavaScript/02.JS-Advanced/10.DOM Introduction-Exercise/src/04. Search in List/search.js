function search() {
   let search = document.getElementById('searchText').value;
   let elements = Array.from(document.querySelectorAll('ul#towns li'));
   elements.forEach(function (el) {
      el.style.textDecoration = 'none';
      el.style.fontWeight = 'normal';
   });
   let matches = elements.filter(s => s.textContent.includes(search));
   matches.forEach(function (el) {
      el.style.textDecoration = 'underline';
      el.style.fontWeight = 'bold';
   });
   document.getElementById('result').textContent = `${matches.length} matches found`;
}
