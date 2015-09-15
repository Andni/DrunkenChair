var eon = eon || {};

(function (ns) {


    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector); });
    };


    ns.selectorChanged = function (selector) {
        var background = $('input[name = SelectedBackground]:checked').val();
        $('#CharacterPreview').load(
            $(selector).data("action-url") +
            '?background=' + background
        );
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('.background-radio', eon.selectorChanged);
});