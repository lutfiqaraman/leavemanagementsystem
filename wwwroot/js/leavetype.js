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
                    { "data": "Name" },
                    { "data": "Description" },
                    { "data": "DateCreated" }
                ],
                "language": {
                    "emptyTable": " No data found "
                }
            });
        });
    }
    
    function Index() {

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
        var self = new Index();
        self.init();
        Grid();
    });

}(jQuery));