var eon = eon || {};

function RemoveWhiteSpace(string)
{
    return string.replace(/(\s|\r\n|\n|\r)/gm, "");
}

function updatePreviewValue(id)
{
    var val = this.val()
    var res = parseInt($(id).text) + val;
    $(id).val(res);
}


eon.CharacterAttributeDetails = {};

eon.CharacterAttributeDetails.UpdatePreviewDetails = function (event) {
    var val = parseInt($(this).val());
    var target = $(event.data);
    var res = parseInt(target.data('value')) + val;
    target.text(res);
};

eon.CharacterAttributeDetails.UpdateOtherSpinnersMaxValue = function (event)
{
    var previousValue = $(this).data('lastValue') || parseInt( $(this).attr('value') );
    var currentValue = parseInt($(this).val());
    var diff = previousValue - currentValue;
    $(this).data('lastValue', currentValue);
    eon.CharacterAttributeDetails.DicesLeftToDistribute = eon.CharacterAttributeDetails.DicesLeftToDistribute + diff;
    
    var CapSpinnerMax = function(index, element)
    {
        var localValue = parseInt($(element).val());
        var localMax = localValue + eon.CharacterAttributeDetails.DicesLeftToDistribute;
        $(element).attr('max', Math.min(localMax, 5));
    }

    $('.attribute-spinner').each(CapSpinnerMax);
    $("#DicesLeftToDistribute").val(eon.CharacterAttributeDetails.DicesLeftToDistribute);
}

eon.CharacterAttributeDetails.UpdateDerivedAttributes = function (jsonStringCharacterData)
{
    data = $.parseJSON(jsonStringCharacterData);

    $('#CharacterConstructionSite_Character_Attributes_Movement_UnlimitedDice6').text(data.Movement.UnlimitedDice6);
    $('#CharacterConstructionSite_Character_Attributes_Impression_UnlimitedDice6').text(data.Impression.UnlimitedDice6);
    $('#CharacterConstructionSite_Character_Attributes_Vigilance_UnlimitedDice6').text(data.Vigilance.UnlimitedDice6);
    $('#CharacterConstructionSite_Character_Attributes_Lifeforce_UnlimitedDice6').text(data.Lifeforce.UnlimitedDice6);
    $('#CharacterConstructionSite_Character_Attributes_Reaction_UnlimitedDice6').text(data.Reaction.UnlimitedDice6);
    $('#CharacterConstructionSite_Character_Attributes_Build_UnlimitedDice6').text(data.Build.UnlimitedDice6);
    $('#CharacterConstructionSite_Character_Attributes_Selfcontrol_UnlimitedDice6').text(data.Selfcontrol.UnlimitedDice6);

    $('#CharacterConstructionSite_Character_Attributes_Movement_Bonus').text(data.Movement.Bonus);
    $('#CharacterConstructionSite_Character_Attributes_Impression_Bonus').text(data.Impression.Bonus);
    $('#CharacterConstructionSite_Character_Attributes_Vigilance_Bonus').text(data.Vigilance.Bonus);
    $('#CharacterConstructionSite_Character_Attributes_Lifeforce_Bonus').text(data.Lifeforce.Bonus);
    $('#CharacterConstructionSite_Character_Attributes_Reaction_Bonus').text(data.Reaction.Bonus);
    $('#CharacterConstructionSite_Character_Attributes_Build_Bonus').text(data.Build.Bonus);
    $('#CharacterConstructionSite_Character_Attributes_Selfcontrol_Bonus').text(data.Selfcontrol.Bonus);

}

eon.CharacterAttributeDetails.Initialize = function () {
    var elements = $('[data-onchange-target]');
    eon.CharacterAttributeDetails.DicesLeftToDistribute = parseInt($("#DicesLeftToDistribute").val());

    elements.each(function (i, e) {
        $(e).on("change", null, null, eon.CharacterAttributeDetails.UpdateOtherSpinnersMaxValue);
        $(e).on("change", null, $(e).data('onchange-target'), eon.CharacterAttributeDetails.UpdatePreviewDetails);
        $(e).on("change", null, null, function () {
            $.get('/EonIvCharacterCreator/GetDerivedAttributes',
                {
                    str: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Strength').text()),
                    sta: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Stamina').text()),
                    agl: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Agility').text()),
                    per: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Perception').text()),
                    wil: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Will').text()),
                    psy: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Psyche').text()),
                    wis: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Wisdom').text()),
                    cha: RemoveWhiteSpace($('#CharacterConstructionSite_Character_Attributes_Charisma').text()),
                },
                eon.CharacterAttributeDetails.UpdateDerivedAttributes);
        });
    });
};

$(document).ready(function () {
    eon.CharacterAttributeDetails.Initialize();
});