function solve(){
   let aothorInputElement = document.getElementById('creator');
   let titleInputElement = document.getElementById('title');
   let categoryInputElement = document.getElementById('category');
   let contentTextElement = document.getElementById('content');
 
   let archiveElement = document.querySelector('.archive-section ol');
 
 
   let sectionElement = document.querySelector('main section');
 
   let button = document.querySelector('button');
 
   button.addEventListener('click', function(e){
 
      let articalEelement = document.createElement('article');
 
      let h1 = document.createElement('h1');
      h1.textContent = titleInputElement.value;
      articalEelement.appendChild(h1);
 
      let p = document.createElement('p');
      p.textContent = 'Category: ';
      let strong = document.createElement('strong');
      strong.textContent = categoryInputElement.value;
 
      p.appendChild(strong);
      articalEelement.appendChild(p);
 
      let creatorParaghraph = document.createElement('p');
      creatorParaghraph.textContent = 'Creator:';
      let creatorStrong = document.createElement('strong');
      creatorStrong.textContent = aothorInputElement.value;
      creatorParaghraph.appendChild(creatorStrong);
      articalEelement.appendChild(creatorParaghraph);
 
      let contentP = document.createElement('p');
      contentP.textContent = contentTextElement.value;
      articalEelement.appendChild(contentP);
 
      let btnDiv = document.createElement('div');
      btnDiv.setAttribute('class', 'buttons');
 
      let deleteButton = document.createElement('button');
      deleteButton.setAttribute('class', 'btn delete');
      deleteButton.textContent = 'Delete';
      btnDiv.appendChild(deleteButton);
      deleteButton.addEventListener('click', function(e){
         sectionElement.removeChild(articalEelement);
      })
 
      let archivButton = document.createElement('button');
      archivButton.setAttribute('class', 'btn archive');
      archivButton.textContent = 'Archive';
      btnDiv.appendChild(archivButton);
      archivButton.addEventListener('click', function(e){
         let li = articalEelement.querySelector('h1');
         let olLiElement = document.createElement('li');
         olLiElement.textContent = li.textContent;
         archiveElement.appendChild(olLiElement);      
 
         sortedArchiv(archiveElement);
      })
 
 
      articalEelement.appendChild(btnDiv);
 
      sectionElement.appendChild(articalEelement);
      e.preventDefault();
   })
 
 
   function sortedArchiv(ol) {
      Array.from(ol.getElementsByTagName("LI"))
          .sort((a, b) => a.textContent.localeCompare(b.textContent))
          .forEach((li) => ol.appendChild(li));
  }
  }
