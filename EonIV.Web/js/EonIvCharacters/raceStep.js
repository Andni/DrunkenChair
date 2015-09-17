var eon = eon || {};

(function (ns) {


    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector); });
    };


    ns.selectorChanged = function (selector) {
        var race = $('#SelectedRace').val();
        $('#CharacterPreview').load(
            $(selector).data("action-url") +
            '?race=' + race
        );
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('#SelectedRace', eon.selectorChanged);
});