using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niklasson.EonIV.Models.DataTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CategorySkillPoints : SkillPointModification
    {

        [Column("SkillCategory")]
        public SkillCategory Category { get; set; }

        public override string ConcreteModelType
        {
            get { return typeof(CategorySkillPoints).ToString(); }
        }
    }
}
