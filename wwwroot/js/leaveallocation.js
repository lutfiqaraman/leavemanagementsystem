var popUp;

$(document).ready(function () {

    var table = $("#leaveAllocationTable").DataTable({
        lengthChange: false,
        select: true,
        dom: 'Bfrtip',

        ajax: {
            url: '/leaveAllocation/GetLeaveAllocation',
            type: 'GET',
            datatype: 'json'
        },

        buttons: [
            {
                text: 'New',
                action: function () {
                    var url = '/leaveAllocation/AddEditLeaveAllocation';
                    PopupForm(url);
                }
            },
            {
                text: 'Edit',
                action: function () {
                    var id = table.rows({ selected: true }).data()[0].id;
                    var url = '/leaveAllocation/AddEditLeaveAllocation/' + id;

                    PopupForm(url);
                }
            },
            {
                text: 'Delete',
                action: function () {
                    var id = table.rows({ selected: true }).data()[0].id;
                    var url = '/leaveAllocation/DeleteLeaveAllocation/' + id;

                    DeleteLeaveAllocation(url);
                }
            }
        ],

        columns: [
            { "data": "leaveTypeId" }
        ]
    });

});

function PopupForm(url) {
    console.log(url);
}

function DeleteLeaveAllocation(url) {
    if (confirm('Are you sure to delete this leave allocation ?')) {
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