function notify(message) {
  let notification = document.getElementById('notification');
  notification.textContent = message;
  notification.style.visibility = 'visible';
  notification.style.display = 'block';
  notification.addEventListener('click', function(ev){
    ev.target.style.visibility = 'hidden';
    ev.target.style.display = 'none';
  })
}