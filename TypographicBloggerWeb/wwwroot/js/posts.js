var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#datatbl").DataTable({
        ajax:
        {
            "url": "Admin/Home/Posts"
        },
        columns:
            [
                { data: "id" },
                { data: "title" },
                { data: "slug" },
                {
                    data: "dateCreated",
                    render: function (data, type, row) {
                        return formatDate(data);
                    }
                }
            ]
    });
}



function formatDate(date) {
    var dateOnly = date.toLocaleString().split("T")[0];
    var timeOnly = date.toLocaleString().split("T")[1].substring(0, 8);

    var formattedDate = dateOnly + " " + timeOnly;

    return formattedDate;
}