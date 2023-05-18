
function loadData() {
    loadProducts();
    loadCategories();
    updateBagCount();
}

async function loadProducts() {
    const products = await fetchProduct();
    drawProducts(products);
}

function setCounter(number) {
    document.querySelector('#counter').innerText = number;    
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

function drawProducts(products) {
    const container = document.getElementById('product-list');
    container.innerHTML = null;
    const cards = products.map(product => designProduct(product));
    cards.forEach(card => container.appendChild(card));
    setCounter(products.length);
}


function designProduct(product) {
    const card = createCard('#template-card');
    card.querySelector('.image').src = `Images/Products/${product.imagePath}`;
    card.querySelector('h1').innerText = product.name;
    card.querySelector('.price').innerText = `$${product.price}`;
    card.querySelector('.description').innerText = product.description;
    card.querySelector('button').addEventListener('click', () => addProduct(product));
    return card;
}

function createCard(type) {
    const template = document.querySelector(type);
    const card = template.content.cloneNode(true);
    return card;
}


async function loadCategories() {
    const categories = await fetchCategories();
    drawCategories(categories);
}

async function fetchCategories() {
    const res = await fetch('api/categories', {
        mehtod: 'Get',
        headers: {
            'Content-type': 'application/json'
        }
    })
    const categories = await res.json();
    return categories;
}

function createUrl(selectedCategories, name, minPrice, maxPrice) {
    let url = `?`;
    if (selectedCategories.length > 0)
        url += `categoryIds=${selectedCategories.join('&categoryIds=')}&`;
    if (name)
        url += `userInput=${name}&`
    if (minPrice)
        url += `minPrice=${minPrice}&`
    if (maxPrice)
        url += `maxPrice=${maxPrice}&`
    return url;
}

async function fetchFilteredProducts(selectedCategories, name, minPrice, maxPrice) {
    const url = createUrl(selectedCategories, name, minPrice, maxPrice);
    const res = await fetch(`api/products${url}`, {
        mehtod: 'Get',
        headers: {
            'Content-type': 'application/json'
        }
    });
    const products = await res.json();
    drawProducts(products);
}

function drawCategories(categories) {
    const designedCategories = categories.map(category => designCategory(category));
    designedCategories.forEach(category => document.querySelector('#category-list').appendChild(category));
}

function filterProducts() {
    const category = document.getElementsByClassName('category-option');
    const selectedCategories = [];
    for (let i = 0; i < category.length; i++)
        if (category[i].checked)
            selectedCategories.push(category[i].value)
    const name = document.getElementById('name-search').value;
    const minPrice = document.getElementById('min-price').value;
    const maxPrice = document.getElementById('max-price').value;
    fetchFilteredProducts(selectedCategories, name, minPrice, maxPrice);
}

function designCategory(category) {
    const card = createCard('#template-category');
    card.querySelector('.option-name').innerText = category.name;
    card.querySelector('.category-option').value = category.id;
    card.querySelector('.category-option').addEventListener('change', filterProducts);
    return card;
}

function updateBagCount() {
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    document.getElementById('items-count-text').innerText = bag.length; 
}

function addProduct(product) {
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    bag.push(product);
    localStorage.setItem('bag', JSON.stringify(bag));
    updateBagCount();    
}