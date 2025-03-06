function loadProducts() {
    $.ajax({
        url: 'https://localhost:7034/api/Product',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            console.log("Dữ liệu nhận từ API:", response);
            $.each(response, function (index, product) {
                $("#product-list").append(
                    `<tr>
                        <td>${index + 1}</td>
                        <td>${product.name}</td>
                        <td>${product.price}</td>
                        <td>${product.quantity}</td>
                        <td>${product.description}</td>
                        <td>${product.brand}</td>
                        <td>${product.category}</td>
                        <td>
                            <img src="/Imgs/Products/${product.image}" width="50px" />
                        </td>
                        <td>
                            <button class="btn btn-warning me-2" onclick="editProduct(${product.id})">
                                <i class="bi bi-pencil-square"></i>
                            </button>
                            <button class="btn btn-danger" onclick="editDelete(${product.id})">
                                <i class="bi bi-x-circle text-black"></i>
                            </button>
                        </td>
                    </tr>`
                )
            })
        },
        error: function (xhr, status, error) {
            console.error("Lỗi: ", error);
        }
    });
}
$(document).ready(function () {
    loadProducts();
});