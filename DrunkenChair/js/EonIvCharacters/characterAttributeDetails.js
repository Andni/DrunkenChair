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

    var prefix = '#Preview_CharacterSheet_Attributes_';
    $(prefix + 'Movement_UnlimitedDice6').text(data.Movement.UnlimitedDice6);
    $(prefix + 'Impression_UnlimitedDice6').text(data.Impression.UnlimitedDice6);
    $(prefix + 'Vigilance_UnlimitedDice6').text(data.Vigilance.UnlimitedDice6);
    $(prefix + 'Lifeforce_UnlimitedDice6').text(data.Lifeforce.UnlimitedDice6);
    $(prefix + 'Reaction_UnlimitedDice6').text(data.Reaction.UnlimitedDice6);
    $(prefix + 'Build_UnlimitedDice6').text(data.Build.UnlimitedDice6);
    $(prefix + 'Selfcontrol_UnlimitedDice6').text(data.Selfcontrol.UnlimitedDice6);

    $(prefix + 'Movement_Bonus').text(data.Movement.Bonus);
    $(prefix + 'Impression_Bonus').text(data.Impression.Bonus);
    $(prefix + 'Vigilance_Bonus').text(data.Vigilance.Bonus);
    $(prefix + 'Lifeforce_Bonus').text(data.Lifeforce.Bonus);
    $(prefix + 'Reaction_Bonus').text(data.Reaction.Bonus);
    $(prefix + 'Build_Bonus').text(data.Build.Bonus);
    $(prefix + 'Selfcontrol_Bonus').text(data.Selfcontrol.Bonus);

}

eon.CharacterAttributeDetails.Initialize = function () {
    var elements = $('[data-onchange-target]');
    eon.CharacterAttributeDetails.DicesLeftToDistribute = parseInt($("#DicesLeftToDistribute").val());

    var prefix = '#Preview_CharacterSheet_Attributes_';
    elements.each(function (i, e) {
        $(e).on("change", null, null, eon.CharacterAttributeDetails.UpdateOtherSpinnersMaxValue);
        $(e).on("change", null, $(e).data('onchange-target'), eon.CharacterAttributeDetails.UpdatePreviewDetails);
        $(e).on("change", null, null, function () {
            $.get('/EonIvCharacterCreator/GetDerivedAttributes',
                {
                    str: RemoveWhiteSpace($(prefix + 'Strength').text()),
                    sta: RemoveWhiteSpace($(prefix + 'Stamina').text()),
                    agl: RemoveWhiteSpace($(prefix + 'Agility').text()),
                    per: RemoveWhiteSpace($(prefix + 'Perception').text()),
                    wil: RemoveWhiteSpace($(prefix + 'Will').text()),
                    psy: RemoveWhiteSpace($(prefix + 'Psyche').text()),
                    wis: RemoveWhiteSpace($(prefix + 'Wisdom').text()),
                    cha: RemoveWhiteSpace($(prefix + 'Charisma').text()),
                },
                eon.CharacterAttributeDetails.UpdateDerivedAttributes);
        });
    });
};

$(document).ready(function () {
    eon.CharacterAttributeDetails.Initialize();
});