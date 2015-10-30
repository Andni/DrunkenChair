var eon = eon || {};

(function (ns) {

    ns.archetypeChanged = function (event) {
        var archetype = $('#SelectedArchetype').val();

        $('#CharacterPreview').load(
            $(event.target).data("action-url") +
            '?archetype=' + archetype
        );

        $("#archetype").load($(event.target).data("get-archetype-url") + '?archetype=' + archetype);
    };  

})(eon)

$(this.document).ready(function () {

    $('#SelectedArchetype').change(eon.archetypeChanged);
});