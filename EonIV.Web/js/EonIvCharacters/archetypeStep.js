var eon = eon || {};

(function (ns) {


    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector); });
    };


    ns.selectorChanged = function (selector) {
        var archetype = $('#SelectedArchetype').val();
        $('#CharacterPreview').load(
            $(selector).data("action-url") +
            '?archetype=' + archetype
        );
        $("#archetype").load(eon.updateArchetypeURL + '?archetype=' + archetype);
    };  

})(eon)

$(this.document).ready(function () {
    eon.attachOnChange('#SelectedArchetype', eon.selectorChanged);
});