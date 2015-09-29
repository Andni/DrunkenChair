namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Resource : CharacterModifier
    {   
        public override string ConcreteModelType
        {
            get { return typeof(Resource).ToString(); }
        }
    }
}
