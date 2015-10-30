var eon = eon || {};

(function (ns) {

    ns.environmentChanged = function (selector) {

        var environment = $('#SelectedEnvironment').val();

        $('#CharacterPreview').load(
            $(event.target).data("action-url") +
            '?environment=' + environment
        );

        $('#eon-environment').load(
            $(event.target).data("get-environment-url") +
            '?environment=' + environment
        );
    };

})(eon)

$(this.document).ready(function () {

    $('#SelectedEnvironment').change(eon.environmentChanged);
});