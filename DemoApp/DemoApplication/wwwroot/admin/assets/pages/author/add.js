$("#save-add-modal").on("click", function () {
    let table = $("#authors-table");
    let form = $("#add-author-form");
    let container = $("#add-author-container");
    let url = form.attr("action");


    $.ajax({
        url: url,
        type: "POST",
        data: form.serialize(),
        complete: function (result) {
            if (result.status == 400) {
                container.html(result.responseText)
            }
            else if (result.status == 201) {
                table.prepend(result.responseText);
            }
            else {
                alert("Something went wrong pls try again");
            }
        }
    })
});