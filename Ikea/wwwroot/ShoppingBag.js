function loadData() {
    loadProducts();
    setTitles();
}

function loadProducts() {
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    const products = bag.map(product => designProduct(product));
    products.forEach(product => document.body.appendChild(product));
}

function setTitles() {
    const itemCount = 5;///
    document.querySelector('#item-count').innerText = itemCount;
    const totalAmount = 99;///
    document.querySelector('#total-amount').innerText = totalAmount;
}

function designProduct(product) {
    const card = createCard('#template-product-card');
    card.querySelector('.description-column').querySelector('.item-name').innerText = product.name;
    card.querySelector('.price').innerText = product.price;
    return card;
}

function createCard(type) {
    const template = document.querySelector(type);
    const card = template.content.cloneNode(true);
    return card;
}

function updateBagCount() {
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    document.getElementById('items-count-text').innerText = bag.length;
}

function addProduct(product) {
    bag.push(product);
    localStorage.setItem('bag', JSON.stringify(bag));
    updateBagCount();
}