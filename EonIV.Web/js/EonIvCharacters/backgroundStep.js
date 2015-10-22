var eon = eon || {};

(function (ns) {

    ns.backgroundChanged = function (event) {
        var background = $('input[name = SelectedBackground]:checked').val();
    
        $('#CharacterPreview').load(
            $(event.target).data("updatePreviewUrl") +
            '?background=' + background
        );

        $('#eon-background').load(
            $(event.target).data("getBackgroundUrl") +
            '?background=' + background
        );
    };


})(eon)

$(this.document).ready(function () {
    $('.background-radio').change(eon.backgroundChanged);
});