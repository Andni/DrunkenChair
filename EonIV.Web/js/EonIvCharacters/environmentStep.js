var eon = eon || {};

(function (ns) {


    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector); });
    };


    ns.selectorChanged = function (selector) {
        var environment = $('#SelectedEnvironment').val();
        $('#CharacterPreview').load(
            $(selector).data("action-url") +
            '?environment=' + environment
        );
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('#SelectedEnvironment', eon.selectorChanged);
});