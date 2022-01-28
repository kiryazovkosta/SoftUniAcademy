function solve() {
  let text = document.getElementById('input').value;
  let output = '';
  let sentences = text.split('.').filter(s => s.length > 0);
  while (sentences.length > 0) {
    output += `<p>${sentences.splice(0, 3).join('.')}.</p>`;
  }

  document.getElementById('output').innerHTML = output;
}