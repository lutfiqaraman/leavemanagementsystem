var popUp, dataTable;

$(document).ready(function () {
    dataTable = $("#leaveTypeTable").DataTable({
        "ajax": {
            "url": "/leavetype/GetLeaveType",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "dateCreated" }
        ]
    });
});

function PopupForm(url) {

    var formDiv = $('<div/>');

    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            popUp = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: 'Add/Edit Leave Type',
                height: 375,
                width: 500,
                close: function () {
                    popUp.dialog('destroy').remove();
                }
            });
        });
}
