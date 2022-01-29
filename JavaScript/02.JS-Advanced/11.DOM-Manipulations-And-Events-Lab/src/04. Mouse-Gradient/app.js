function attachGradientEvents() {
    let gradient = document.getElementById('gradient-box');
    let result = document.getElementById('result');
    gradient.addEventListener('mousemove', function(event) {
        let percentage = (event.offsetX / (event.target.clientWidth -1)) * 100;
      result.textContent = `${Math.floor(percentage)}%`
    });
    gradient.addEventListener('mouseleave', function(){
        result.textContent = '';
    })
}