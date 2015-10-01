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
    };

    ns.toggleDisable = function () {
        var inputDecendants = $(this).parent().find("input[type='checkbox'], input[type='radio']");
        inputDecendants.each(eon.Toggle);
    };

    ns.Toggle = function () {
        var disabled = $(this).prop("checked");
        var inputSiblings = $(this).siblings().find("input").not("input[type='hidden']");
        if (disabled) {
            inputSiblings.prop("disabled", false);
        }
        else {
            inputSiblings.prop("disabled", true);
        }
    };

})(eon)

document.addEventListener('DOMContentLoaded', function () {
    $("#resources").find("input[type='checkbox'], input[type='radio']").change(eon.toggleDisable);
});