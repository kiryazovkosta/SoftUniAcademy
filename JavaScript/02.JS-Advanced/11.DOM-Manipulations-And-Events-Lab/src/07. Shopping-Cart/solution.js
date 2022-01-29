function solve() {
   let products = [];

   let outputArea = document.querySelector('textarea');
   let cheoutButton = document.querySelector('button.checkout');
   let buttons = Array.from(document.querySelectorAll('button.add-product'));

   buttons.forEach(button => button.addEventListener('click', addProduct));
   cheoutButton.addEventListener('click', checkout);

   function addProduct(event) {
      let root = event.currentTarget.parentElement.parentElement;
      let name = root.querySelector('div.product-details div.product-title').textContent;
      let money = root.querySelector('div.product-line-price').textContent;
      let product = {
         name: name,
         money: Number(money),
         toString : function() {
            return `Added ${this.name} for ${this.money.toFixed(2)} to the cart.\n`;
         }
      }
      outputArea.value += product.toString();
      products.push(product);
   }

   function checkout(event){
      let totalPrice = 0;
      let list = [];
      for (const product of products) {
         totalPrice += product.money;
         if (!list.includes(product.name)) {
            list.push(product.name)
         }
      }

      let output = `You bought ${list.join(', ')} for ${totalPrice.toFixed(2)}.`;
      outputArea.value += output;
      buttons.forEach(b => b.disabled = true);
   }
}