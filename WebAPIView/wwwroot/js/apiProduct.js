$(function () {
    loadproducts();
});

//Get
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
                            <button class="btn btn-danger" onclick="deleteProduct(${product.id})">
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


// Create
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
    } else {
        console.log("Validate false rồi")
        console.log($("#imageTextNameFileHidden").val())
    }
});


//Edit
function editProduct(id) {
    document.getElementById("create").style.display = "none";
    document.getElementById("update").style.display = "inline";
    document.getElementById("backToCreate").style.display = "inline";

    $.ajax({
        url: `https://localhost:7034/api/Product/${id}`,
        type: 'GET',
        dataType: 'json',
        success: function (product) {
            $("#idProduct").val(product.id);
            $("#name").val(product.name);
            $("#price").val(product.price);
            $("#quantity").val(product.quantity);
            $("#description").val(product.description);
            $("#brandid option").each(function () {
                if ($(this).text() === product.brand) {
                    $("#brandid").val($(this).val());
                }
            });
            $("#categoryid option").each(function () {
                if ($(this).text() === product.category) {
                    $("#categoryid").val($(this).val());
                }
            });
            $("#imageTextNameFileHidden").val(product.image)
            $("#imageProduct").html(
                `<img src="/Imgs/Products/${product.image}" width="100px" />`
            )
        },
        error: function (xhr, status, error) {
            alert("Lỗi khi lấy sản phẩm: " + xhr.responseText);
            console.error(error);
        }
    })
}

// Button lưu update
$("#update").click(function () {
    let isValid = validateInput();
    if (isValid == true) {
        let id = $("#idProduct").val();
        let imageName = $("#imageTextNameFileHidden").val();
        if ($("#imageFile").val().split("\\").pop() != "") {
            imageName = $("#imageFile").val().split("\\").pop();
        }

        let product = {
            id: $("#idProduct").val(),
            name: $("#name").val(),
            price: $("#price").val(),
            image: imageName,
            quantity: $("#quantity").val(),
            brandId: $("#brandid").val(),
            categoryId: $("#categoryid").val(),
            description: $("#description").val()
        };

        let productJson = JSON.stringify(product);

        $.ajax({
            url: `https://localhost:7034/api/Product/${id}`,
            type: 'PUT',
            contentType: 'application/json',
            data: productJson,
            success: function (response) {
                alert("Cập nhật xong !!");
                loadproducts();
                resetForm();
                console.log(response);
            },
            error: function (xhr, status, error) {
                alert("Lỗi cập nhật sản phẩm: " + xhr.responseText);
                console.error(error);
            }
        })
    }
    else console.log("Lỗi nhập dữ liệu")
})

//Delete
function deleteProduct(id) {
    if (confirm(`Xác nhận xoá?`)) {
        $.ajax({
            url: `https://localhost:7034/api/Product/${id}`,
            type: 'DELETE',
            success: function (response) {
                alert('Xoá thành công');
                loadproducts();
            },
            error: function (xhr, status, error) {
                alert("Lỗi khi xoá: " + xhr.responseText);
                console.error(error);
            }
        })
    }
}

// Hàm cho Button huỷ Update
function resetForm() {
    document.getElementById("create").style.display = "inline";
    document.getElementById("update").style.display = "none";
    document.getElementById("backToCreate").style.display = "none";

    $("#idProduct").val("")
    $("#imageTextNameFileHidden").val("");
    $("#name").val("");
    $("#price").val("");
    $("#quantity").val("");
    $("#description").val("");
    $("#brandid").val("");
    $("#categoryid").val("");
    $("#imageFile").val("");
    $("#imageProduct").empty();
}


//Điều kiện nhập Form
function validateInput() {
    $(".error-message").text("");
    let isValid = true;

    $(".form .form-notnull").each(function () {
        if ($(this).val().trim() === "") {
            $(this).next(".error-message").text("không được để trống")
            isValid = false;
        }
    })

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

    if ($("#imageTextNameFileHidden").val() === "") {
        let imageName = $("#imageFile").val().split("\\").pop();
        if (imageName === "") {
            $("#imageFile").next(".error-message").text("Vui lòng thêm file ảnh");
            isValid = false;
        }
    }

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

    return isValid;
}
