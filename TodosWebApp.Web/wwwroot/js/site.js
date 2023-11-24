// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function MyFunction(id)
{
    jsonData = {
        id: id,
        name: $("#name"+id).text(),
        isDone: $("#isDone"+id).is(":checked"),
        dueDate: $("#dueDate"+id).text(),
        createdDate: $("#createdDate" + id).text()
    }

    console.log(jsonData);

    $.ajax({
        type: "POST",
        url: "/todo/updateisdone",
        data: jsonData,
        error: function(error)
        {
            alert(error);
        }
    });
}