using Local.Rest.ModelDTO.AlergenosDTO;
using Local.Rest.ModelDTO.IngredientesDTO;
using Local.Rest.ModelDTO.PlatosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Local.Rest.ApiSoap.Interfaces
{
    [ServiceContract]
    public interface ISoapService
    {
        #region Platos
        [ServiceContract]
        int InsertarPlato(PlatosDTO PlatoItem);
        [ServiceContract]
        int InsertarPlatoIngrediente(int IdPlato, int IdIngrediente);
        [ServiceContract]
        Task<IEnumerable<PlatosDTO>> ListarPlatos();
        [ServiceContract]
        Task<IEnumerable<PlatosDTO>> ListarPlatosByName(string NombrePlato);
        #endregion

        #region Ingredientes
        [ServiceContract]
        int InsertarIngrediente(IngredientesDTO IngredienteItem);
        #endregion

        #region Alergenos
        [ServiceContract]
        int InsertarAlergeno(AlergenosDTO AlergenosItem);
        #endregion
    }
}
