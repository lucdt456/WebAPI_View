$(function () {
    loadproducts();
});
function loadproducts() {
    $.ajax({
        url: 'https://localhost:7034/api/Product',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            console.log("Dữ liệu nhận từ API:", response);
            $("#product-list").empty();
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

$("#create").click(function () {
    /*console.log('Tạo 1 sản phẩm')*/
    let isValid = validateInput();
    if (isValid == true) {
        let product = {
            name: $("#name").val(),
            price: $("#price").val(),
            image: $("#imageFile").val().split("\\").pop(),
            quantity: $("#quantity").val(),
            brandId: $("#brandid").val(),
            categoryId: $("#categoryid").val(),
            description: $("#description").val()
        };
        productJson = JSON.stringify(product);
        $.ajax({
            url: 'https://localhost:7034/api/Product',
            type: "POST",
            contentType: "application/json",
            data: productJson,
            success: function (response) {
                alert("Tạo sản phẩm thành công!");
                loadproducts();
                console.log(response);
            },
            error: function (xhr, status, error) {
                alert("Lỗi tạo sản phẩm: " + xhr.responseText);
                console.error(error);
            }
        })
    }
});

function validateInput() {
    $(".error-message").text("");
    let isValid = true;

    $(".form .form-control").each(function () {
        if ($(this).val().trim() === "") {
            $(this).next(".error-message").text("Không được để trống")
            isValid = false;
        } 
    })

    let name = $("#name").val();
    if (name.length > 20) {
        $("#name").next(".error-message").text("Không được nhập quá 20 ký tự !!!");
        isValid = false;
    }

    let price = parseFloat($("#price").val());
    if (price < 0) {
        $("#price").next(".error-message").text("Giá sản phẩm phải >= 0");
        isValid = false;
    }

    let quantity = parseFloat($("#quantity").val());
    if (quantity != parseInt($("#quantity").val())) {
        $("#quantity").next(".error-message").text("Vui lòng nhập số nguyên");
        isValid = false;
    }
    if (quantity < 0) {
        $("#quantity").next(".error-message").text("Số lượng sản phẩm phải >= 0");
        isValid = false;
    }

    let brandId = $("#brandid").val();
    if (brandId === "") {
        $("#brandid").next(".error-message").text("Vui lòng chọn thương hiệu");
        isValid = false;
    }

    let categoryId = $("#categoryid").val();
    if (categoryId === "") {
        $("#categoryid").next(".error-message").text("Vui lòng chọn loại sản phẩm");
        isValid = false;
    }

    let imageName = $("#imageFile").val().split("\\").pop();
    if (imageName === "") {
        $("#imageFile").next(".error-message").text("Vui lòng thêm file ảnh");
        isValid = false;
    }
    return isValid;
}

$("#test").click(function () {
    validateInput();
})
