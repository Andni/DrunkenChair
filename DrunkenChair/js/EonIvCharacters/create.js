var eon = eon || {};

(function (ns) {

    
    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector);});
    };


    ns.selectorChanged = function (selector)  {
        var archetype = $('#Archetype').val();
        var environment = $('#Environment').val();
        var race = $('#Race').val();
        $('#divCharacterPreview').load(
            $(selector).data("action-url") +
            '?archetype=' + archetype +
            '&environment=' + environment +
            '&race=' + race
            );
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('#Archetype', eon.selectorChanged);
    eon.attachOnChange('#Environment', eon.selectorChanged);
    eon.attachOnChange('#Race', eon.selectorChanged);

    //$('#Race').change(function () {
    //    var selection = $('#Race').val();
    //    $('#divCharacterPreview').load(
    //        $('#Race').data("action-url") + '?archetype=Krigare&environment=Hav&race='
    //        //'/EonIvCharacters/GetCharacterPreview?archetype=Krigare&environment=Hav&race='
    //        + selection);
    //});
});