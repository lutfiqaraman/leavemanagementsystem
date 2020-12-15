var popUp;

$(document).ready(function () {

    var table = $("#leaveTypeTable").DataTable({
        lengthChange: false,
        select: true,
        dom: 'Bfrtip',
        
        ajax: {
            url: '/leavetype/GetLeaveType',
            type: 'GET',
            datatype: 'json'
        },

        buttons: [
            {
                text: 'New',
                action: function () {
                    var url = '/leavetype/AddEditLeaveType';
                    PopupForm(url);
                }
            },
            {
                text: 'Edit',
                action: function () {
                    var id = table.rows({ selected: true }).data()[0].id;
                    var url = '/leavetype/AddEditLeaveType/' + id;
     
                    PopupForm(url);
                }
            },
            {
                text: 'Delete',
                action: function () {
                    var id  = table.rows({ selected: true }).data()[0].id;
                    var url = '/leavetype/DeleteLeaveType/' + id;

                    DeleteLeaveType(url);
                }
            }
        ],

        columns: [
            { "data": "name" },
            { "data": "description" },
            { "data": "defaultDays" }
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
                modal: true,
                resizable: false,
                title: 'Add/Edit Leave Type',
                height: 375,
                width: 550,
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
            $.notify('Saved Successfully ...', {
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

function DeleteLeaveType(url) {
    if (confirm('Are you sure to delete this leave type')) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (data) {
                if (data.success) {
                    $.notify('Deleted successfully ...', {
                        globalPosition: 'left center',
                        className: 'success'
                    });

                    window.location.reload();
                }
            }
        })
    }
}
