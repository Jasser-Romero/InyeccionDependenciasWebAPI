using InyeccionDependencias.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InyeccionDependencias.Models.Repositorios
{
    public class RepositorioPaises : RepositorioGenerico<WebApiPaisesEntities, Paises>, IRepositorioPaises
    {

    }
}