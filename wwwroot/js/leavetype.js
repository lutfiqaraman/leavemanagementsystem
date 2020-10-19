$('document').ready(function () {
    $('#leavetypetable').DataTable({
        "ajax": {
            "url": "/LeaveType/GetLeaveTypes",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Name" },
            { "data": "Description" },
            { "data": "DateCreated" }
        ]
    });
});