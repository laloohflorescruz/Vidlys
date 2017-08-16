(function ($) {
    function Customer() {
        var $this = this;

        function initializeModel() {
            $("#modal-action-customer").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.model');
            });
        }
        $this.init = function () {
            initializeModel();
        }
    }
    $(function () {
        var self = new Customer();
        self.init();
    })
}(JQuery))
