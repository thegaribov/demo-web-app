$(document).on("click", ".remove-button", function (e) {
    e.preventDefault();

    let url = e.target.href;
    let row = e.target.parentElement.parentElement;

    $.ajax({
        url: url,
        type: "DELETE",
        complete: function (result) {
            if (result.status == 204) {
                $(row).remove();
            }
            else {
                alert("Something went wrong pls try again");
            }
        }
    })
});