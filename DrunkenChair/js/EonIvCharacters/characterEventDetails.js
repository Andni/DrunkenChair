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
    $(this).parent().parent().load("/EonIvCharacterCreator/RerollEvent", { index: event.data.index, category: event.data.EventCategory });
};

eon.CharacterEventDetails.Initialize = function () {
    var elements = $(".reroll");
    elements.each(function (index, element) {
        $(element).on(
            "click",
            null,
            {
                EventCategory: parseInt($(element).data("eventcategory")),
                index: eon.CharacterEventDetails.ParseIndexFromId($(element).attr("id"))
            },
            eon.CharacterEventDetails.RerollEvent2)
    });
};

eon.CharacterEventDetails.ParseIndexFromId = function (elementIdString)
{
    var start = elementIdString.indexOf('[');
    var end = elementIdString.indexOf(']');
    return parseInt(elementIdString.substring(start + 1, end));
}

$(document).ready(function () {
    eon.CharacterEventDetails.Initialize();
});
