using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{

    public abstract class CharacterModifierNode
    {
        [Key]
        public int ID { get; set; }
           
    }

    public class CharacterModifierContainer : CharacterModifierNode, IEnumerable<CharacterModifierNode>
    {
        private List<CharacterModifierNode> children = new List<CharacterModifierNode>();
        public virtual ICollection<CharacterModifierNode> Children {
            get { return children; }
        }
        
        
    public void Add(CharacterModifierNode node)
        {
            Children.Add(node);
        }

        public IEnumerator<CharacterModifierNode> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}