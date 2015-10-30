var eon = eon || {};

(function (ns) {

    ns.raceChanged = function (event) {

        var race = $('#SelectedRace').val();

        $('#CharacterPreview').load(
            $(event.target).data("action-url") +
            '?race=' + race
        );

        $('#race').load(
            $(event.target).data("get-race-url") +
            '?race=' + race
        );
    };

})(eon)

$(this.document).ready(function () {
    $('#SelectedRace').change(eon.raceChanged);
});