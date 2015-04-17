var eon = eon || {};

(function (ns) {

    
    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector);});
    };


    ns.selectorChanged = function (selector)  {
        var archetype = $('#selectedArchetype').val();
        var environment = $('#selectedEnvironment').val();
        var race = $('#selectedRace').val();
        $('#divCharacterPreview').load(
            $(selector).data("action-url") +
            '?archetype=' + archetype +
            '&environment=' + environment +
            '&race=' + race
            );
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('#selectedArchetype', eon.selectorChanged);
    eon.attachOnChange('#selectedEnvironment', eon.selectorChanged);
    eon.attachOnChange('#selectedRace', eon.selectorChanged);
});