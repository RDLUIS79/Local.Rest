using Local.Rest.ApiSoap.Interfaces;
using Local.Rest.ServiceRest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local.Rest.ApiSoap.Servicios
{
    public class SoapService: ISoapService
    {
        IRestService _restService;
        public SoapService()
        {
            _restService = new RestService();
        }
        public int InsertarPlato(ModelDTO.PlatosDTO.PlatosDTO PlatoItem)
        {
            return _restService.InsertarPlato(PlatoItem);
        }
        public int InsertarPlatoIngrediente(int IdPlato, int IdIngrediente)
        {
            return _restService.InsertarPlatoIngrediente(IdPlato, IdIngrediente);
        }
        public Task<IEnumerable<ModelDTO.PlatosDTO.PlatosDTO>> ListarPlatos()
        {
            return _restService.ListarPlatos();
        }
        public Task<IEnumerable<ModelDTO.PlatosDTO.PlatosDTO>> ListarPlatosByName(string NombrePlato)
        {
            return _restService.ListarPlatosByName(NombrePlato);
        }
        public int InsertarIngrediente(ModelDTO.IngredientesDTO.IngredientesDTO IngredienteItem)
        {
            return _restService.InsertarIngrediente(IngredienteItem);
        }
        public int InsertarAlergeno(ModelDTO.AlergenosDTO.AlergenosDTO AlergenosItem)
        {
            return _restService.InsertarAlergeno(AlergenosItem);
        }
    }
}
