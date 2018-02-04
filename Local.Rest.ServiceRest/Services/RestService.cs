using Local.Rest.ModelDTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using Local.Rest.ModelDTO.PlatosDTO;
using Local.Rest.ModelDTO.IngredientesDTO;

namespace Local.Rest.ServiceRest.Services
{
    public class RestService : IRestService
    {
        public RestService()
        {
            //
        }
        public int InsertarPlato(PlatosDTO PlatoItem)
        {
            using (modelEntities db = new modelEntities())
            //using (TeastRestEntities db = new TeastRestEntities())
            {
                db.Entry(new PLATOS()
                {
                    ACTIVO = PlatoItem.Activo,
                    MOMENTO = PlatoItem.Momento,
                    NOMBRE = PlatoItem.NombrePlato
                }).State = System.Data.Entity.EntityState.Added;

                return db.SaveChanges();
            }
        }
        public int InsertarPlatoIngrediente(int IdPlato, int IdIngrediente)
        {
            using (modelEntities db = new modelEntities())
            //using (TeastRestEntities db = new TeastRestEntities())
            {
                db.Entry(new PLATOS_ING()
                {
                    ACTIVO = true,
                    ID_PLATO = IdPlato,
                    ID_INGREDIENTE = IdIngrediente,
                    MOMENTO = DateTime.Now
                }).State = System.Data.Entity.EntityState.Added;

                return db.SaveChanges();
            }
        }
        private async Task<PlatosDTO> RellenaPlatos(PlatosDTO Plato)
        {
            return await Task.Run(() =>
            {
                using (modelEntities db = new modelEntities())
                //using (TeastRestEntities db = new TeastRestEntities())
                {
                    var _Plato = (from T in db.PLATOS where T.ID == Plato.IdPlato select T).FirstOrDefault();
                    Plato.Activo = _Plato.ACTIVO;
                    Plato.Momento = _Plato.MOMENTO;
                    Plato.NombrePlato = _Plato.NOMBRE;
                    var _ingredientes = (from T in db.PLATOS_ING
                                          join P in db.INGREDIENTES on T.ID_INGREDIENTE equals P.ID
                                          where T.ID_PLATO == Plato.IdPlato && P.ACTIVO == true
                                          select P).ToList();
                    
                    Plato.Ingredientes = new List<IngredientesDTO>();
                    Plato.Alergenos = new List<ModelDTO.AlergenosDTO.AlergenosDTO>();
                    _ingredientes.ForEach(x=> {
                        Plato.Ingredientes.Add(new IngredientesDTO() {
                            Activo = x.ACTIVO,
                            IdIngrediente = x.ID,
                            Momento = x.MOMENTO,
                            NombreIngrediente = x.NOMBRE
                        });

                        var _alergeno = (from T in db.INGREDIENTES
                                        join P in db.ALERGENOS on T.ID equals P.ID_INGREDIENTE
                                        where T.ID == x.ID && P.ACTIVO == true
                                        select P).ToList();

                        _alergeno.ForEach(s =>
                        {
                            Plato.Alergenos.Add(new ModelDTO.AlergenosDTO.AlergenosDTO()
                            {
                                Activo = s.ACTIVO,
                                IdAlergeno= s.ID,
                                IdIngrediente = s.ID_INGREDIENTE,
                                Momento = s.MOMENTO,
                                NombreAlergeno = s.NOMBRE
                            });

                        });

                    });
                     
                    return Plato;
                }
            });
        }
        public async Task<IEnumerable<ModelDTO.PlatosDTO.PlatosDTO>> ListarPlatos()
        {
            using (modelEntities db = new modelEntities())
            //using (TeastRestEntities db = new TeastRestEntities())
            {
                var _platos = (from T in db.PLATOS select T).ToList();
                List<PlatosDTO> ListaPlatos = new List<PlatosDTO>();
                _platos.ForEach(x =>
                {

                    // Buscamos los ingredientes del plato
                    //var _ingredientes = (from T in db.PLATOS_ING
                    //             join P in db.INGREDIENTES on T.ID_INGREDIENTE equals P.ID
                    //             where T.ID_PLATO == x.ID && P.ACTIVO == true
                    //             select P).ToList();

                    //List<IngredientesDTO> ListOfIngredientes = new List<IngredientesDTO>();
                    
                    ListaPlatos.Add(new PlatosDTO()
                    {
                        NombrePlato = x.NOMBRE,
                        Momento = x.MOMENTO,
                        IdPlato = x.ID,
                        Activo = x.ACTIVO,
                    });
                });
                var Platos = ListaPlatos.Select(x => RellenaPlatos(x));
                return await Task.WhenAll(Platos);
            }
        }
        public async Task<IEnumerable<PlatosDTO>> ListarPlatosByName(string NombrePlato)
        {
            using (modelEntities db = new modelEntities())
            //using (TeastRestEntities db = new TeastRestEntities())
            {
                var _platos = (from T in db.PLATOS where T.NOMBRE.ToUpper() == NombrePlato.ToUpper() select T).ToList();
                List<PlatosDTO> ListaPlatos = new List<PlatosDTO>();
                _platos.ForEach(x =>
                {
                    ListaPlatos.Add(new PlatosDTO()
                    {
                        NombrePlato = x.NOMBRE,
                        Momento = x.MOMENTO,
                        IdPlato = x.ID,
                        Activo = x.ACTIVO
                    });
                });
                var Platos = ListaPlatos.Select(x => RellenaPlatos(x));
                return await Task.WhenAll(Platos);
            }
        }
        public int InsertarIngrediente(ModelDTO.IngredientesDTO.IngredientesDTO IngredienteItem)
        {
            using (modelEntities db = new modelEntities())
            //using (TeastRestEntities db = new TeastRestEntities())
            {
                db.Entry(new INGREDIENTES()
                {
                    ACTIVO = IngredienteItem.Activo,
                    MOMENTO = IngredienteItem.Momento,
                    NOMBRE = IngredienteItem.NombreIngrediente
                }).State = System.Data.Entity.EntityState.Added;

                return db.SaveChanges();
            }
        }
        public int InsertarAlergeno(ModelDTO.AlergenosDTO.AlergenosDTO AlergenosItem)
        {
            using (modelEntities db = new modelEntities())
            //using (TeastRestEntities db = new TeastRestEntities())
            {
                db.Entry(new ALERGENOS()
                {
                    ID_INGREDIENTE = AlergenosItem.IdIngrediente,
                    ACTIVO = AlergenosItem.Activo,
                    MOMENTO = AlergenosItem.Momento,
                    NOMBRE = AlergenosItem.NombreAlergeno
                }).State = System.Data.Entity.EntityState.Added;

                return db.SaveChanges();
            }
        }
    }
}
