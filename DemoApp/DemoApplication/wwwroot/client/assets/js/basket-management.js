let baskets = []

const BASKET_PRODUCTS_KEY = "products";
let cardBlock = $(".cart-block")


// #region Initial setups

setupAddTriggers();

setupRemoveTriggers();

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

function addProduct(event) {
    event.preventDefault();

    let endpoint = $(event.target).attr("href");
    console.log(endpoint)

    $.ajax({
        url: endpoint,
        success: function (response) {
            console.log(response)
            cardBlock.html(response);
        }
    });
}




// #endregion


// #region Remove product and show

function removeProduct(event) {
    event.preventDefault();
    console.log(event)
}


// #endregion
