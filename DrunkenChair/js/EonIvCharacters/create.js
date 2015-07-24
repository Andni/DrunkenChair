var eon = eon || {};

(function (ns) {

    
    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector);});
    };


    ns.selectorChanged = function (selector)  {
        var archetype = $('#SelectedArchetype').val();
        var environment = $('#SelectedEnvironment').val();
        var race = $('#SelectedRace').val();
        $('#CharacterPreview').load(
            $(selector).data("action-url") +
            '?archetype=' + archetype +
            '&environment=' + environment +
            '&race=' + race
            );
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('#SelectedArchetype', eon.selectorChanged);
    eon.attachOnChange('#SelectedEnvironment', eon.selectorChanged);
    eon.attachOnChange('#SelectedRace', eon.selectorChanged);
});