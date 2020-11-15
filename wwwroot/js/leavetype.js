﻿var popUp;

$(document).ready(function () {

    var table = $("#leaveTypeTable").DataTable({
        lengthChange: false,
        select: true,
        dom: 'Bfrtip',
        
        "ajax": {
            "url": "/leavetype/GetLeaveType",
            "type": "GET",
            "datatype": "json"
        },

        buttons: [
            {
                text: 'New',
                action: function (e, dt, node, config) {
                    PopupForm();
                }
            },
            {
                text: 'Edit',
                action: function (e, dt, node, config) {
                    PopupForm();
                }
            },
            {
                text: 'Delete',
                action: function (e, dt, node, config) {
                    alert('Button activated');
                }
            }
        ],

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

function SubmitForm(form) {

    $.ajax({
        type: 'POST',
        url: form.action,
        data: $(form).serialize(),
        success: function () {
            popUp.dialog('close');
            dataTable.ajax.reload();
            $.notify('Saved Successfully', {
                globalPosition: 'left center',
                className: 'success'
            });
        },
        error: function (error) {
            $.notify(error, {
                globalPosition: 'left center',
                className: 'error'
            })
        }
    });

    return false;
}
