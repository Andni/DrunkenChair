using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class ItemProperties : IEnumerable<ItemProperty>
    {
        [Key]
        public int ItemPropertiesId { get; set; }

        private List<ItemProperty> properties { get; set; } = new List<ItemProperty>();

        public void Add(ItemProperty p)
        {
            properties.Add(p);
        }

        public IEnumerator<ItemProperty> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}