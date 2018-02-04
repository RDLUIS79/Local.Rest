using Local.Rest.ApiSoap.Interfaces;
using Local.Rest.ModelDTO.AlergenosDTO;
using Local.Rest.ModelDTO.IngredientesDTO;
using Local.Rest.ModelDTO.PlatosDTO;
using Local.Rest.ServiceRest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Local.Rest.ApiSoap.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SoapService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SoapService.svc o SoapService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SoapService : ISoapService
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
