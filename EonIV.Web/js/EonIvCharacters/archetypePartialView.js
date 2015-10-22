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

    ns.DisableOtherCheckboxesIfTwoAreChecked = function () {
        var checkboxes = $("#pickTwoResources").find("input:checkbox");
        var numberOfCheckedBoxes = 0;
        checkboxes.each(function ()
        {
            if($(this).prop("checked"))
            {
                numberOfCheckedBoxes++;
            }
        });

        if(numberOfCheckedBoxes >= 2)
        {
            var nonChecked = checkboxes.not(":checked");
            nonChecked.prop("disabled", true)
            nonChecked.siblings("*").css("opacity", 0.6);
        }
        else
        {
            checkboxes.prop("disabled", false);
            checkboxes.siblings("*").css("opacity", 1);
        }

        if(numberOfCheckedBoxes >= 2)
        {
            var data = $("form").serializeArray();
            $.post("/EonIvCharacterCreator/SetArchetype", data,  function(data, textStatus, jqXHR) {
                $("#CharacterPreview").replaceWith(data);
            });
        }
    }

})(eon)

document.addEventListener('DOMContentLoaded', function () {
    $("#resources").find("input[type='checkbox'], input[type='radio']").change(eon.toggleDisable);
    $("#pickTwoResources").find("input:checkbox").change(eon.DisableOtherCheckboxesIfTwoAreChecked);

    //child inputs of pickTwoResources starts off as disabled
    $("#pickTwoResources").children(".character-modifier-choise-container-entries").children(".character-modifier-entry").children(".character-modifier-choise-container-entries").children(".character-modifier-entry").children("input").not(":hidden").prop("disabled", true);
});