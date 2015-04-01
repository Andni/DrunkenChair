using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

using DrunkenChair.Models.Interfaces;

namespace DrunkenChair.Models.DatabaseTables
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [NotMapped]
        public List<EonIVCharacterModifier> Modifications { get; set; }

        [Column("CharacterModifications")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string CharacterModificationsXml
        {
            get
            {
                var serializer = new XmlSerializer(Modifications.GetType(), new Type[] { typeof(Skill), typeof(CharacterBaseAttributes)} );
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, Modifications.ToList());
                    stringWriter.Flush();
                    return stringWriter.ToString();
                }
            }
            set
            {
                var serializer = new XmlSerializer(Modifications.GetType(), new Type[] { typeof(Skill), typeof(CharacterBaseAttributes)} );
                using (var stringReader = new StringReader(value))
                {
                    Modifications = (List<EonIVCharacterModifier>)serializer.Deserialize(stringReader);
                }
            }
        }
    }
}