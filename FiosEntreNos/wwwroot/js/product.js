$(document).ready(function () {
    getAllProducts();
});

function getAllProducts() {
    $.ajax({
        type: "GET",
        url: urlGetAllProducts,
        success: function (data) {
            $("#grid-all-products").html(data);
        },
        error: function (data) {
            alert(data.responseText, "Erro!");
        }
    })
}