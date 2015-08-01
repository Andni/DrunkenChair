namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterGenerationData
    {
        private CharacterData character;

        public CharacterGenerationData(CharacterData character)
        {
            this.character = character;
            Skillpoints = new Skillpoints();
            ResourceOptions = new ResourceOptions();
        }

        public EventTableRolls EventRolls
        {
            get
            {
                return character.Basics.GetEventRolls();
            }
        }

        public ResourceOptions ResourceOptions { get; }
        public CharacterBaseAttributeSet BonusDiceDistribution { get; set; }
        public Skillpoints Skillpoints { get; set; }


        public int FreeEventRolls { get; set; }

    }
}
