using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public interface IApoliceNegocio
    {
        Retorno<object> Get(int id);
        Retorno<object> GetAll();
        Retorno<object> Add(Apolice model);
        Retorno Update(int id, Apolice model);
        Retorno Delete(int id);
    }
}
