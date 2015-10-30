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

        protected string label;

        public virtual string Label {
            get { return label; }
            set { label = value; }
        }

        protected string description;

        public virtual string Description {
            get { return description; }
            set { description = value; }
        }

        public int? ParentNodeId{ get; set; }

        [ForeignKey("ParentNodeId")]
        public virtual CharacterModifierNode Parent { get; set; }

        public abstract IList<CharacterModifier> Flatten();
    }

    public class CharacterModifierContainer : CharacterModifierNode, IEnumerable<CharacterModifierNode>
    {
        private List<CharacterModifierNode> children = new List<CharacterModifierNode>();

        public CharacterModifierContainer() { }

        public CharacterModifierContainer(string label, string description)
        {
            Label = label;
            Description = description;
        }

        [ForeignKey("ParentNodeId")]
        public virtual List<CharacterModifierNode> Children
        {
            get { return children; }
        }

        public bool GotOnlyLeafChildren
        {
            get
            {
                var containerChildren = children.FindAll(m => m.GetType().IsSubclassOf(typeof(CharacterModifierContainer)));
                if (containerChildren.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool NoSelectionChildren
        {
            get
            {
                var single = children.FindAll(m => m.GetType().IsSubclassOf(typeof(CharacterModifierContainerSingleChoice)));
                var multi = children.FindAll(m => m.GetType().IsSubclassOf(typeof(CharacterModifierContainerMultiChoice)));
                if (multi.Count > 0 || single.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public override string ConcreteModelType {
            get { return typeof(CharacterModifierContainer).ToString(); }
        }

        public CharacterModifierContainerMultiChoice CooseTwoResources { get; internal set; }

        public virtual void Add(CharacterModifierNode node)
        {
            if (node != null)
            {
                node.Parent = this;
                Children.Add(node);
            }
        }

        public override IList<CharacterModifier> Flatten()
        {
            var res = new List<CharacterModifier>();
            foreach (CharacterModifierNode n in Children)
            {
                var c = n as CharacterModifierContainer;
                if (c != null)
                {
                    res.AddRange(c.Flatten());
                }

                var c1 = n as CharacterModifier;
                if (c1 != null)
                {
                    res.Add(c1);
                }
            }
            return res;
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