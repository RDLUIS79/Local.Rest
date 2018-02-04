using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Local.Rest.ModelDTO.PlatosDTO
{
    public class PlatosDTO
    {
        [DataMember]
        public int IdPlato { get; set; }
        [DataMember]
        public string NombrePlato { get; set; }
        [DataMember]
        public DateTime Momento { get; set; }
        [DataMember]
        public bool Activo { get; set; }
        [DataMember]
        public List<IngredientesDTO.IngredientesDTO> Ingredientes { get; set; }
        [DataMember]
        public List<AlergenosDTO.AlergenosDTO> Alergenos { get; set; }
    }
}
