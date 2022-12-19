$(document).on("click", ".remove-button", function (e) {
    e.preventDefault();

    let url = e.target.href;
    let row = e.target.parentElement.parentElement;
    console.log(url)
    console.log(row)


    $.ajax({
        url: url,
        type: "DELETE",
        complete: function (result) {
            if (result.status == 204) {
                console.log("No content")
                $(row).remove();
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