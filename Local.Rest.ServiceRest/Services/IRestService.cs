using Local.Rest.ModelDTO.AlergenosDTO;
using Local.Rest.ModelDTO.IngredientesDTO;
using Local.Rest.ModelDTO.PlatosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local.Rest.ServiceRest.Services
{
    public interface IRestService
    {
        #region Platos
        int InsertarPlato(PlatosDTO PlatoItem);
        int InsertarPlatoIngrediente(int IdPlato, int IdIngrediente);
        Task<IEnumerable<PlatosDTO>> ListarPlatos();
        Task<IEnumerable<PlatosDTO>> ListarPlatosByName(string NombrePlato);
        #endregion

        #region Ingredientes
        int InsertarIngrediente(IngredientesDTO IngredienteItem);
        #endregion

        #region Alergenos
        int InsertarAlergeno(AlergenosDTO AlergenosItem);
        #endregion
    }
}
