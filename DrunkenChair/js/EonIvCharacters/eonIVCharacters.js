var eon = eon || {};


(function (ns) {


    ns.attachOnChange = function (selector, fun) {
        $(selector).change(function () { fun(selector); });
    };


    ns.adjustAttribute = function (attributeSelector) {

        $('#divCharacterPreview').load(
            $(attributeSelector).data("action-url") +
            '?archetype=' + archetype +
            '&environment=' + environment +
            '&race=' + race
            );
    };

})(eon)

$(this.document).ready(function () {

});