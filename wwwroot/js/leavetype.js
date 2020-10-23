(function ($) {

    function Grid() {
        $('document').ready(function () {

            $('#leavetypetable').DataTable({
                "ajax": {
                    "url": "/LeaveType/GetLeaveTypes",
                    "type": "GET",
                    "datatype": "json"
                },
                "columns": [
                    { "data": "name" },
                    { "data": "description" },
                    { "data": "dateCreated" },
                    {
                        "data": "Id", "render": function () {
                            return "<a class='btn btn-outline-secondary'><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-outline-danger' style='margin-left: 5px'><i class='fa fa-trash'></i> Delete</a>"
                        },
                        "orderable": false
                    }
                ],
                "language": {
                    "emptyTable": " No data found "
                }
            });
        });
    }
    
    function Modal() {
        
        var $this = this;

        function initialize() {

            $(".popup").on('click', function (e) {
                modelPopup(this);
            });

            function modelPopup(reff) {
                
                var url = $(reff).data('url');

                $.get(url).done(function (data) {
                    $('#modal-add-edit').find(".modal-dialog").html(data);
                    $('#modal-add-edit > .modal', data).modal("show");
                });

            }
        }

        $this.init = function () {
            initialize();
        };
    }

    $(function () {
        var leaveTypeModal = new Modal();
        leaveTypeModal.init();

        Grid();
    });

}(jQuery));