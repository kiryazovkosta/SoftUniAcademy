function solve() {
  let text = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;

  let words = text
    .split(' ')
    .map(x => x.charAt(0).toUpperCase() + x.slice(1).toLowerCase());

  let output;
  const printOutput = {
    'Camel Case': function () {
      return words[0].charAt(0).toLowerCase() + words[0].slice(1) + words.slice(1).join('');
    },
    'Pascal Case': function () {
      return words.join('');
    },
    'default': function () {
      return 'Error!';
    },
  };

  output = (printOutput[convention] || printOutput['default'])();

  document.getElementById('result').textContent = output;
}