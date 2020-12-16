var popUp;

$(document).ready(function () {
    
    var table = $("#employeesTable").DataTable({
        lengthChange: false,
        select: true,
        dom: 'Bfrtip',

        ajax: {
            url: '/employees/GetEmployees',
            type: 'GET',
            datatype: 'json'
        },

        buttons: [
            {
                text: 'New',
                action: function () {
                    var url = '/employees/AddEditEmployees';
                    PopupForm(url);
                }
            },
            {
                text: 'Edit',
                action: function () {
                    var id = table.rows({ selected: true }).data()[0].id;
                    var url = '/employees/AddEditEmployees/' + id;

                    PopupForm(url);
                }
            },
            {
                text: 'Delete',
                action: function () {
                    var id = table.rows({ selected: true }).data()[0].id;
                    var url = '/employees/DeleteEmployees/' + id;

                    DeleteEmployees(url);
                }
            }
        ],

        columns: [
            { "data": "username" },
            { "data": "email" },
            { "data": "phonenumber" },
            { "data": "firstname" },
            { "data": "lastname" },
            { "data": "taxid" },
            { "data": "dateofbirth" },
            { "data": "datejoin" },
        ]
    });

});