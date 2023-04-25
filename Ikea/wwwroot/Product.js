
function loadData() {
    // commit
    loadProducts();
    loadCategories();
}

async function loadProducts() {
    const products = await fetchProduct();
    drowProducts(products);
}

async function fetchProduct() {
    const res = await fetch("api/products", {
        method: 'Get',
        headers: {
            'Content-Type': 'application/json'
        },
    })
    const products = await res.json();
    return products;
}

function drowProducts(products) {
    const cards = products.map(product => designProduct(product));
    cards.forEach(card => document.body.appendChild(card))
}

function helloWorld() { }

function designProduct(product) {
    const card = createCard('#template-card');  
    card.querySelector('.image').src = `Images/Products/${product.imagePath}`;
    card.querySelector('h1').innerText = product.name;
    card.querySelector('.price').innerText = `${product.price}$`;
    card.querySelector('.description').innerText = product.description;
    return card;
}

function createCard(type) {
    const template = document.querySelector(type);
    const card = template.content.cloneNode(true);
    return card;
}


async function loadCategories() {
    const categories = await fetchCategories();
    drowCategories(categories);
}

async function fetchCategories(){
    const res = await fetch('api/categories', {
        mehtod: 'Get',
        headers: {
            'Content-type': 'application/json'
        }
    })
    const categories = await res.json();
    return categories;
}

function drowCategories(categories) {
    const designedCategories = categories.map(category => designCategory(category));
    designedCategories.forEach(category => document.querySelector('#categoryList').appendChild(category));
}


function designCategory(category) {
    const card = createCard('#template-category');
    card.querySelector('.OptionName').innerText = category.name;
    return card;
}

//window.addEventListener('load', fetchProduct());
//document.body.addEventListener('load', fetchProduct());