var pageConfirmation = function () {
    var initConfirmation = function () {

        $('.deleteConfirm').confirmation({
            placement: "left",
            title: "Silmek istediğinizden emin misiniz?",
            btnOkClass: "btn btn-sm btn-success",
            btnCancelClass: "btn btn-sm btn-danger",
            container: 'body',
            btnCancelLabel: 'Hayır',
            btnOkLabel: 'Evet'
        });
    }
    return {
        //main function to initiate the module
        init: function () {
            initConfirmation();
        }
    };
}();