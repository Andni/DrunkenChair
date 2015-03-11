﻿var eon = eon || {};

(function (ns) {

    
    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector);});
    };


    ns.selectorChanged = function (selector)  {
        var selection = $(selector).val();
        //this.style("color = red");
        $('#divCharacterPreview').load(
            $(selector).data("action-url") + '?archetype=Krigare&environment=Hav&race='
            //'/EonIvCharacters/GetCharacterPreview?archetype=Krigare&environment=Hav&race='
            + selection);
    };

})(eon)

$(this.document).ready(function () {

    eon.attachOnChange('#Race', eon.selectorChanged);

    //$('#Race').change(function () {
    //    var selection = $('#Race').val();
    //    $('#divCharacterPreview').load(
    //        $('#Race').data("action-url") + '?archetype=Krigare&environment=Hav&race='
    //        //'/EonIvCharacters/GetCharacterPreview?archetype=Krigare&environment=Hav&race='
    //        + selection);
    //});
});