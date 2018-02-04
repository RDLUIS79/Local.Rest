namespace Local.Rest.ApiRest.Controllers
{
    using Local.Rest.ModelDTO.AlergenosDTO;
    using Local.Rest.ModelDTO.IngredientesDTO;
    using Local.Rest.ModelDTO.Model;
    using Local.Rest.ModelDTO.PlatosDTO;
    using Local.Rest.ServiceRest.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Controlador de ejemplo
    /// </summary>
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        IRestService _restService;
        /// <summary>
        /// Constructor
        /// </summary>
        public ValuesController()
        {
            _restService = new RestService();
        }
        /// <summary>
        /// Obtiene la lista de todos los platos creados
        /// </summary>
        /// <response code="200">OK</response>
        /// <returns></returns>
        [HttpGet]
        [Route("ListaPlatos")]
        public async Task<IHttpActionResult> ListaPlatos()
        {
            return Ok(await _restService.ListarPlatos());
        }
        /// <summary>
        /// Devuelve la lista de platos por nombre.
        /// </summary>
        /// <param name="NombrePlato">Nombre del plato de la busqueda</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("ListarPlatosByName/{NombrePlato}")]
        public async Task<IHttpActionResult> ListarPlatosByName(string NombrePlato)
        {
            return Ok(await _restService.ListarPlatosByName(NombrePlato));
        }
        /// <summary>
        /// Inserta un nuevo plato en la base de datos
        /// </summary>
        /// <param name="PlatoItem">Objeto con la informacion del palto</param>
        /// <returns></returns>
        [HttpPut]
        [Route("InsertarPlato")]
        public IHttpActionResult InsertarPlato([FromBody] PlatosDTO PlatoItem)
        {
            return Ok(_restService.InsertarPlato(PlatoItem));
        }
        /// <summary>
        /// Añade un ingrediente a un plato determinado
        /// </summary>
        /// <param name="IdPlato"></param>
        /// <param name="IdIngrediente"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("InsertarPlatoIngrediente/{IdPlato}/{IdIngrediente}")]
        public IHttpActionResult InsertarPlatoIngrediente(int IdPlato, int IdIngrediente)
        {
            return Ok(_restService.InsertarPlatoIngrediente(IdPlato, IdIngrediente));
        }
        /// <summary>
        /// Inserta un nuevoingrediente en la base de datos
        /// </summary>
        /// <param name="IngredienteItem">Objeto con la informacion del ingrediente</param>
        /// <returns></returns>
        [HttpPut]
        [Route("InsertarIngrediente")]
        public IHttpActionResult InsertarIngrediente([FromBody] IngredientesDTO IngredienteItem)
        {
            return Ok(_restService.InsertarIngrediente(IngredienteItem));
        }
        /// <summary>
        /// Añade un alergeno de un ingrediente
        /// </summary>
        /// <param name="AlergenosItem"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("InsertarAlergeno")]
        public IHttpActionResult InsertarAlergeno([FromBody] AlergenosDTO AlergenosItem)
        {
            return Ok(_restService.InsertarAlergeno(AlergenosItem));
        }        
    }
}