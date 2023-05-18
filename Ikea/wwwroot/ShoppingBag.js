function onLoad() {
    loadData();
    addListeners();
    isEmpty();
}

async function loadData() {
    const products = await getProducts();
    drawProducts(products);
    setTitles(products);
}

async function isEmpty() {
    const products = await getProducts();
    if (products.length == 0) {
        const container = document.querySelector('.container');
        container.innerHTML = 'no products';
    }
}

function addListeners() {
    const button = document.querySelector('#submit-order');
    button.addEventListener('click', submitOrder);
}

async function submitOrder() {
    const userId = getUserId();
    if (!userId) {
        alert('You are you are forward to the login page');
        window.location.assign("./home.html?fromShoppingBag=true");
    };

    const error = document.querySelector('#order-error');
    error.innerText = '';
    const button = document.querySelector('#submit-order');
    button.disabled = true;
    button.innerText = 'loading...';
    button.style.backgroudColor = 'grey';

    const products = getProducts();

    const orderItems = products.map((p) => ({
        productId: p.id,
        quantity: 1,
    }));

    const order = {
        date: new Date(),
        sum: totalSum(products),
        userId,
        orderItems,
    };

    const res = await fetch('/api/orders', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(order),
    });

    if (res.ok) {
        const o = await res.json();
        postOrder(o.id);
    }
    else {
        error.innerText = "order process failed";
        button.disabled = false;
        button.innerText = 'click to order';
        button.style.backgroudColor = '#0070C0';
    }
}

function postOrder(id) {
    localStorage.removeItem('bag');
    const container = document.querySelector('.container');
    container.innerHTML = null;
    const p = document.createElement('p');
    p.innerText = `Order Id ${id}`;
    container.appendChild(p);

    const button = document.createElement('button');
    button.innerText = `Continue Shopping`;
    button.addEventListener('click', continueToShopping)
    container.appendChild(button);

}

function continueToShopping() {
    window.location.assign('./Products.html');
}
function getUserId() {
    const user = JSON.parse(sessionStorage.getItem('user') || '{}');
    return user.id;
}

function drawProducts(products) {
    const list = document.querySelector('#product-list');
    const fragment = document.createDocumentFragment();

    products.forEach((product) => {
        const productCard = designProduct(product);
        fragment.appendChild(productCard);
    });

    list.appendChild(fragment);
}

function getProducts() {
    const bag = localStorage.getItem('bag') || '[]';
    return JSON.parse(bag);
}

function setTitles(products) {
    const itemCount = products.length;
    document.querySelector('#item-count').textContent = itemCount;
    document.querySelector('#total-amount').textContent = totalSum(products);
}

function totalSum(products) {
    return products.reduce((sum, product) => sum + product.price, 0);
}

function designProduct(product) {
    const card = createCard('#template-product-card');
    card.querySelector('.description').textContent = product.name;
    card.querySelector('.price').textContent = product.price;
    card.querySelector('.image').setAttribute('src', `Images/Products/${product.imagePath}`);
    card.querySelector('.delete').addEventListener('click', (e) => removeProductFromBag(e, product.id));
    return card;
}

function removeProductFromBag(event, productId) {
    const card = event.target.parentNode.parentNode;
    card.remove();
    const products = removeProductFromLocalStorage(productId);
    setTitles(products);
    isEmpty();
}

function removeProductFromLocalStorage(productId) {
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    const updatedBag = bag.filter((p) => p.id !== productId);
    localStorage.setItem('bag', JSON.stringify(updatedBag));
    return updatedBag;
}

function createCard(type) {
    const template = document.querySelector(type);
    return template.content.cloneNode(true);
}
