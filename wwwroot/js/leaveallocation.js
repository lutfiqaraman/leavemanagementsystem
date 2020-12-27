var popUp;

$(document).ready(function () {

    var table = $("#leaveAllocationTable").DataTable({
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
                    var id = table.rows({ selected: true }).data()[0].id;
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