using InyeccionDependencias.Contratos;
using InyeccionDependencias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InyeccionDependencias.Controllers
{
    public class PaisesController : ApiController
    {
        private readonly IRepositorioPaises repositorioPaises;

        public PaisesController(IRepositorioPaises repositorioPaises)
        {
            this.repositorioPaises = repositorioPaises;
        }

        // GET: api/Paises
        public IEnumerable<Paises> Get()
        {
            return repositorioPaises.ObtenerTodos();
        }

        // GET: api/Paises/5
        public Paises Get(int id)
        {
            return repositorioPaises.ObtenerPor(p => p.Id == id).First();
        }

        // POST: api/Paises
        public void Post([FromBody]Paises pais)
        {
            repositorioPaises.Agregar(pais);
        }

        // PUT: api/Paises/5
        public void Put(int id, [FromBody]Paises pais)
        {
            repositorioPaises.Editar(pais);
        }

        // DELETE: api/Paises/5
        public void Delete(int id)
        {

        }
    }
}
