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

function previewMultipleImages(input) {
    const previewContainer = document.getElementById('ImagePreviewContainer');
    previewContainer.innerHTML = '';

    if (input.files) {
        Array.from(input.files).forEach(file => {
            const reader = new FileReader();

            reader.onload = function (e) {
                const img = document.createElement('img');
                img.src = e.target.result;
                img.className = 'img-thumbnail me-2 mb-2';
                img.style.maxWidth = '150px';
                previewContainer.appendChild(img);
            };

            reader.readAsDataURL(file);
        });
    }
}