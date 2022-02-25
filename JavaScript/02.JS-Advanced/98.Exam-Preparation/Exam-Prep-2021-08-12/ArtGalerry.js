class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture":200,"photo":50,"item":250 };
        this.listOfArticles = [];
        this.guests = [];
        
    }

    addArticle(articleModel, articleName, quantity){
        articleModel = articleModel.toLowerCase();
        quantity = Number(quantity);
        if (!this.possibleArticles[articleModel]) {
            return 'This article model is not included in this gallery!';
        } else {
            let article = this.listOfArticles.find(a => a.articleName === articleName && a.articleModel === articleModel);
            if (article) {
                article.quantity += quantity;
            } else {
                this.listOfArticles.push({
                    articleModel, 
                    articleName, 
                    quantity
                });
            }

            return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
        }
    }

    inviteGuest ( guestName, personality) {
        if (this.guests.some(g => g.guestName === guestName)) {
           throw new Error(`${guestName} has already been invited.`); 
        } else {
            let points = 50;
            switch(personality.toLowerCase()){
                case 'vip': points = 500; break;
                case 'middle': points = 250; break;
                default: points = 50; break;
            }

            this.guests.push({
                guestName,
                points,
                purchaseArticle: 0
            })

            return `You have successfully invited ${guestName}!`;
        }
    }
}

const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
// artGallery.buyArticle('picture', 'Mona Liza', 'John');
// artGallery.buyArticle('item', 'Ancient vase', 'Peter');
// console.log(artGallery.showGalleryInfo('article'));
// console.log(artGallery.showGalleryInfo('guest'));
