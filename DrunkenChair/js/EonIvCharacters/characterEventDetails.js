var eon = eon || {};

eon.CharacterEventDetails = {};

eon.CharacterEventDetails.ReplaceEvent = function (data, textStatus, jqXHR)
{
    var button = $(this);
    var event = button.parent();

    var tmp = event.children(".number");

};


eon.CharacterEventDetails.RerollEvent = function RerollEvent(event) {
    $.ajax("/EonIvCharacterCreator/GetRandomEvent",
        {
            context: event.target,
            method: "POST",
            data: JSON.stringify({ eventCategory: event.data }),
            success: eon.CharacterEventDetails.ReplaceEvent
        }
    );
};


eon.CharacterEventDetails.RerollEvent2 = function RerollEvent(event) {
    $(this).parent().parent().load("/EonIvCharacterCreator/RerollEvent", { index: 0, category: 2});
};

eon.CharacterEventDetails.Initialize = function () {
    var elements = $(".reroll");
    elements.each(function (index, element) {
        $(element).on("click", null, $(element).data("eventCategory"),  eon.CharacterEventDetails.RerollEvent2)
    });
};

$(document).ready(function () {
    eon.CharacterEventDetails.Initialize();
});
