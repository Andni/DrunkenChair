using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Niklasson.EonIV.CharacterGeneration.BusinessObjects
{
    [ComplexType]
    public class CharacterJadedness
    {
        public int VulnrabilityLevel { get; set; }
        public int ViolenceLevel { get; set; }
        public int SupernaturalLevel { get; set; }
    }
}
