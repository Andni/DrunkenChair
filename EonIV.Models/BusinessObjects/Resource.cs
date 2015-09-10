namespace Niklasson.EonIV.Models.BusinessObjects
{
    class Resource : CharacterModifier
    {   
        public override string ConcreteModelType
        {
            get { return typeof(Resource).ToString(); }
        }
    }
}
