var eon = eon || {};

(function (ns) {

    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector); });
    };

    ns.selectorChanged = function (selector) {
        var m = $('#SelectedBackground').val();
        $('#CharacterPreview').load(
            $(selector).data("action-url") +
            '?background=' + m
        );
    };

})(eon)

document.addEventListener('DOMContentLoaded', function () {
    $("#modifications").find("input:radio").change(eon.selectorChanged);
    $("#pickTwoResources").find("input:checkbox").change(eon.DisableOtherCheckboxesIfTwoAreChecked);

    //child inputs of pickTwoResources starts off as disabled
    $("#pickTwoResources").children(".character-modifier-entry").children(".character-modifier-choise-container-entries").children(".character-modifier-entry").children("input").not(":hidden").prop("disabled", true);
});