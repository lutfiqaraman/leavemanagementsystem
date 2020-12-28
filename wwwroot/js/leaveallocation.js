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

                    DeleteLeaveType(url);
                }
            }
        ],

        columns: [
            { "data": "leaveTypes" }
        ]
    });

});