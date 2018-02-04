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
        [OperationContract]
        int InsertarPlato(PlatosDTO PlatoItem);
        [OperationContract]
        int InsertarPlatoIngrediente(int IdPlato, int IdIngrediente);
        [OperationContract]
        Task<IEnumerable<PlatosDTO>> ListarPlatos();
        [OperationContract]
        Task<IEnumerable<PlatosDTO>> ListarPlatosByName(string NombrePlato);
        #endregion

        #region Ingredientes
        [OperationContract]
        int InsertarIngrediente(IngredientesDTO IngredienteItem);
        #endregion

        #region Alergenos
        [OperationContract]
        int InsertarAlergeno(AlergenosDTO AlergenosItem);
        #endregion
    }
}
