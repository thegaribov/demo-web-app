let baskets = []

const BASKET_PRODUCTS_KEY = "products";

// #region Initial setups

intitializeProductsCookie();

setupAddTriggers();

syncBasketWithCookie();

setupRemoveTriggers();

function intitializeProductsCookie() {
    if (!is_cookie_exists(BASKET_PRODUCTS_KEY)) {
        reset_cookie(BASKET_PRODUCTS_KEY);
    }
}

function setupAddTriggers() {

    let addButtons = document.querySelectorAll(".add-product-to-basket-btn")
    addButtons.forEach(b => b.addEventListener("click", this.addProduct));
}

function setupRemoveTriggers() {
    let removeButtons = document.querySelectorAll(".remove-product-to-basket-btn")
    removeButtons.forEach(b => b.addEventListener("click", this.removeProduct));
}



// #endregion

// #region Add and update products and show

function prepareProductObj(element) {
    let quantity = 1;
    let price = parseInt($(element).data("price"));
    let total = price * quantity;

    return {
        id: $(element).data("id"),
        imageUrL: $(element).data("image-url"),
        title: $(element).data("title"),
        price: price,
        quantity: quantity,
        total: total
    }
}

function addProduct(event) {
    event.preventDefault();
    let productObj = prepareProductObj(event.target);
    addProductToCookie(productObj)
}

function addProductToCookie(productObj) {
    let products = read_cookie(BASKET_PRODUCTS_KEY);
    let target_product = products.find(po => po.id == productObj.id)

    if (target_product == undefined) {
        products.push(productObj);
        add_cookie(BASKET_PRODUCTS_KEY, products)
    }
    else {
        products.forEach(function (p) {
            if (p.id == target_product.id) {
                p.quantity++;
                p.total = target_product.quantity * target_product.price;
            }
        })

        add_cookie(BASKET_PRODUCTS_KEY, products)
    }

    syncBasketWithCookie();

    setupRemoveTriggers();
}

function syncBasketWithCookie() {
    let products = read_cookie(BASKET_PRODUCTS_KEY);
    let basketCartMini = document.getElementById("basket-cart-mini");

    basketCartMini.innerHTML = "";

    products.forEach(p => {
        basketCartMini.innerHTML += prepareProductElement(p);
    })
}

function prepareProductElement(productObj) {
    return `<div class="cart-product">
                <a href="product-details.html" class="image">
                    <img src="${productObj.imageUrL}" alt="">
                </a>
                <div class="content">
                    <h3 class="title">
                        <a href="product-details.html">
                           ${productObj.title}
                        </a>
                    </h3>
                    <p class="price"><span class="qty">${productObj.quantity} ×</span> £${productObj.price}</p>
                    <button data-id="${productObj.id}" class="cross-btn remove-product-to-basket-btn"><i class="fas fa-times"></i></button>
                </div>
            </div>`
}

// #endregion


// #region Remove product and show

function removeProduct(event) {
    event.preventDefault();
    removeProductFromCookie(event.target);
    removeProductElement(event.target);
}

function removeProductElement(element) {
    let productElement = element.parentElement.parentElement.parentElement;
    productElement.remove();
}

function removeProductFromCookie(element) {
    let id = $(element.parentElement).data("id");

    let products = read_cookie(BASKET_PRODUCTS_KEY);

    products = products.filter(p => p.id != id);

    add_cookie(BASKET_PRODUCTS_KEY, products)
}

// #endregion
