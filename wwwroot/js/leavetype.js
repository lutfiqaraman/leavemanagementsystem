(function ($) {

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
    });

}(jQuery));