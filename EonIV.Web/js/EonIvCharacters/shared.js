var eon = eon || {};

(function (ns) {

    ns.ConstructInputTree = function (jqSelectorString) {
        $(jqSelectorString).children(".character-modifier-choise-container-entries").children(".character-modifier-entry").children("input").not(":hidden");

    };
})(eon)