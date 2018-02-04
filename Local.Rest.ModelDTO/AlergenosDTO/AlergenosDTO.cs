using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Local.Rest.ModelDTO.AlergenosDTO
{
    public class AlergenosDTO
    {
        [DataMember]
        public int IdAlergeno { get; set; }
        [DataMember]
        public int IdIngrediente { get; set; }
        [DataMember]
        public string NombreAlergeno { get; set; }
        [DataMember]
        public DateTime? Momento { get; set; }
        [DataMember]
        public bool? Activo { get; set; }
    }
}
