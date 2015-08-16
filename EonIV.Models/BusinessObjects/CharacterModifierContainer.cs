using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Deployment.Internal;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace Niklasson.EonIV.Models.BusinessObjects
{

    public abstract class CharacterModifierNode
    {
        [Key]
        public int ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public abstract string ConcreteModelType { get; }

        public virtual CharacterModifierNode Parent { get; set; }
           
    }

    public class CharacterModifierContainer : CharacterModifierNode, IEnumerable<CharacterModifierNode>
    {
        private List<CharacterModifierNode> children = new List<CharacterModifierNode>();
        public virtual IList<CharacterModifierNode> Children {
            get { return children; }
        }
        
        public override string ConcreteModelType {
            get { return typeof(CharacterModifierContainer).ToString(); }
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

        public CharacterModifierNode this[int key] => children[key];
    }
}