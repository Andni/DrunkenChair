$(this.document).ready(function () {
    $('#Race').change(function () {
        var race = $('#Race').val();
        var environment = $('#Environment').val();
        var archetype = $('#Archetype').val();
        $('#divCharacterPreview').load(
            '/EonIvCharacters/GetCharacterPreview?archetype=' + archetype + '&environment=' + environment + '&race=' + race);
    });
});