function validateInput() {
    let formElement = document.querySelector(".form")
    let inputElement = formElement.querySelectorAll(".form-control")

    for (let i = 0; i < inputElement.length; i++) {
        if (inputElement[i].value === "") {
            inputElement[i].parentElement.querySelector(".error-message").textContent = `Vui lòng nhập đầy đủ thông tin ${inputElement[i].id}`
        } else inputElement[i].parentElement.querySelector(".error-message").textContent = "";
    }
}

function addNew() {
    validateInput()
    let formElement = document.querySelector(".form");
    let errorElement = formElement.querySelectorAll(".error-message");
    let arrErrorElement = [];
    for (let i = 0; i < errorElement.length; i++) {
        arrErrorElement.push(errorElement[i].textContent)
    }
    let checkErrorElemen = arrErrorElement.every(value => value === "")
    if (checkErrorElemen == true) {
        let name = document.getElementById("name").value
        let price = document.getElementById("price").value
        let quantity = document.getElementById("quantity").value
        let listProduct = localStorage.getItem("list-product") ? JSON.parse(localStorage.getItem("list-product")) : []
        listProduct.push({
            name: name,
            price: price,
            quantity: quantity
        })

        localStorage.setItem("list-product", JSON.stringify(listProduct))
        renderProduct()
    }
}

function renderProduct() {
    let listProduct = localStorage.getItem("list-product") ? JSON.parse(localStorage.getItem("list-product")) : []

    let product = `<thead class="table-dark">
                        <tr>
                            <th width="10%">STT</th>
                            <th width="35%">Tên</th>
                            <th width="25%">Giá</th>
                            <th width="10%">SL</th>
                            <th width="20%"></th>
                        </tr>
                    </thead>`
    listProduct.map((value, index) => {
        product += `<tr>
                    <td>${index + 1}</td>
                    <td>${value.name}</td>
                    <td>${value.price}</td>
                    <td>${value.quantity}</td>
                    <td>
                        <button onclick="editProduct(${index})" class="btn btn-warning">Edit</button>
                        <button onclick="deleteProduct(${index})" class="btn btn-danger">Delete</button>
                    </td>
                </tr>`
    })
    document.getElementById("product-table").innerHTML = product
}

function editProduct(index) {
    let listProduct = localStorage.getItem("list-product") ? JSON.parse(localStorage.getItem("list-product")) : []
    document.getElementById("name").value = listProduct[index].name
    document.getElementById("price").value = listProduct[index].price
    document.getElementById("quantity").value = listProduct[index].quantity
    document.getElementById("index").value = index
    document.getElementById("create").style.display = "none"
    document.getElementById("update").style.display = "inline"

}

function updateProduct() {
    let listProduct = localStorage.getItem("list-product") ? JSON.parse(localStorage.getItem("list-product")) : []
    let index = document.getElementById("index").value
    if (confirm("Sửa sản phẩm này?")) {
        listProduct[index] = {
            name: document.getElementById("name").value,
            price: document.getElementById("price").value,
            quantity: document.getElementById("quantity").value
        }
        localStorage.setItem("list-product", JSON.stringify(listProduct))
        renderProduct();

        // Reset form và hiển thị lại nút "Tạo sản phẩm mới"
        document.getElementById("name").value = "";
        document.getElementById("price").value = "";
        document.getElementById("quantity").value = "";
        document.getElementById("index").value = "";
        document.getElementById("create").style.display = "inline";
        document.getElementById("update").style.display = "none";
    }

}

function deleteProduct(index) {
    let listProduct = localStorage.getItem("list-product") ? JSON.parse(localStorage.getItem("list-product")) : []
    if (confirm("Xoá sản phẩm này?")) {
        listProduct.splice(index, 1)
    }

    localStorage.setItem("list-product", JSON.stringify(listProduct))
    renderProduct();

}