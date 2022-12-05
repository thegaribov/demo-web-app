let baskets = {}

class BasketManagement {
    constructor(){
        this.setupAddTriggers();
    }

    readProducts() {

    }

    addProduct(event) {
        event.preventDefault();

        helloWorld();

        let productObj = this.prepareProductObj(event.target);
        //baskets.push(productObj);
    }

    helloWorld() {
        console.log("sdsda")
    }

    prepareProductObj(element) {
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

    removeProduct() {

    }

    updateProduct() {

    }

    setupAddTriggers() {
        let addButtons = document.querySelectorAll(".add-product-to-basket-btn")
        addButtons.forEach(b => b.addEventListener("click", this.addProduct));
    }
}

class Rectangle {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
    // Getter
    get area() {
        return this.calcArea();
    }
    // Method
    calcArea() {
        return this.height * this.width;
    }
}