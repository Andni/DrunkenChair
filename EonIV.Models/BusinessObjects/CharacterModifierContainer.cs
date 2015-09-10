using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace Niklasson.EonIV.Models.BusinessObjects
{

    public abstract class CharacterModifierNode
    {
        [Key]
        public int ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public abstract string ConcreteModelType { get; }
        
        public int? ParentNodeId{ get; set; }

        [ForeignKey("ParentNodeId")]
        public virtual CharacterModifierNode Parent { get; set; }
    }

    public class CharacterModifierContainer : CharacterModifierNode, IEnumerable<CharacterModifierNode>
    {
        //private List<CharacterModifierNode> children = new List<CharacterModifierNode>();

        [ForeignKey("ParentNodeId")]
        public virtual List<CharacterModifierNode> Children
        {
            //get { return children; }
            get; set;
        } = new List<CharacterModifierNode>();

        public override string ConcreteModelType {
            get { return typeof(CharacterModifierContainer).ToString(); }
        }

        public void Add(CharacterModifierNode node)
        {
            if (node != null)
            {
                node.Parent = this;
                Children.Add(node);
            }
        }

        public IEnumerator<CharacterModifierNode> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CharacterModifierNode this[int key] => Children[key];
    }
}