$(document).on("click", ".update-button", function (e) {
    let container = $("#update-author-container");
    let url = e.target.href;
    let targetId = $(e.target.parentElement.parentElement).data("id");

    $("#target-url").val(url)
    $("#target-id").val(targetId)

    $.ajax({
        url: url,
        type: "GET",
        complete: function (result) {
            if (result.status == 200) {
                container.html(result.responseText);
            }
            else {
                alert("Something went wrong")
            }
        }
    })
});


$(document).on("click", "#save-updates-button", function (e) {
    let updateModal = $("#updateAuthorModal");
    let container = $("#update-author-container");
    let firstName = $("#update-first-name").val();
    let lastName = $("#update-last-name").val();
    let targetUrl = $("#target-url").val();
    let targetId = $("#target-id").val();
    let targetRow = $(`.author-record[data-id='${targetId}']`)

    $.ajax({
        url: targetUrl,
        type: "PUT",
        data: { firstName: firstName, lastName: lastName },
        complete: function (result) {
            if (result.status == 400) {
                container.html(result.responseText);
            }
            else if (result.status == 200)
            {
                targetRow.replaceWith(result.responseText)
                updateModal.modal("hide");
            }
            else {
                alert("Something went wrong")
            }
        }
    })
});