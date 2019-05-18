using Model;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
   public class ApoliceNegocio : IApoliceNegocio
    {
        private readonly SeguroDbContext _seguroDBContext;

        public ApoliceNegocio(SeguroDbContext seguroDBContext)
        {
            _seguroDBContext = seguroDBContext;
        }
        public Retorno<object> Get(int id)
        {
            Retorno<object> oRet = new Retorno<object>();
            var apolice = new Apolice();
            try
            {
                apolice = (from p in _seguroDBContext.Apolice
                           where p.NumApolice == id
                           select p).FirstOrDefault();

                oRet.setSuccesso();
                oRet.Object = apolice;
            }
            catch (System.Exception ex)
            {
                oRet.setErro(ex.Message);
            }
            return oRet;
        }
        public Retorno<object> GetAll()
        {
            Retorno<object> oRet = new Retorno<object>();
            var lstApolices = new List<Apolice>();
            try
            {
                lstApolices = (from p in _seguroDBContext.Apolice
                                   select p).ToList();
                oRet.setSuccesso();
                oRet.Object = lstApolices;
            }
            catch (System.Exception ex)
            {
                oRet.setErro(ex.Message);
            }
            return oRet;
        }
        public Retorno<object> Add(Apolice model)
        {
            Retorno<object> oRet = new Retorno<object>();

            try
            {
                if (String.IsNullOrEmpty(model.CPFCNPJ))
                    throw new Exception("Informe o CPF/CNPJ");
                if (String.IsNullOrEmpty(model.Placa))
                    throw new Exception("Informe a placa");
                if(model.ValorPremio <= 0)
                    throw new Exception("Informe um valor válido");

                _seguroDBContext.Add(model);
                _seguroDBContext.SaveChanges();
                oRet.setSuccesso();
                oRet.Object = model;
            }
            catch(System.Exception ex)
            {
                oRet.setErro(ex.Message);
            }
            return oRet;
        }
        public Retorno Update(int id, Apolice model)
        {
            Retorno oRet = new Retorno();
            try
            {
                if (String.IsNullOrEmpty(model.CPFCNPJ))
                    throw new Exception("Informe o CPF/CNPJ");
                if (String.IsNullOrEmpty(model.Placa))
                    throw new Exception("Informe a placa");
                if (model.ValorPremio <= 0)
                    throw new Exception("Informe um valor válido");

                var apolice = (from p in _seguroDBContext.Apolice
                               where p.NumApolice == id
                               select p).FirstOrDefault();
                if (apolice != null)
                {
                    apolice.CPFCNPJ = model.CPFCNPJ;
                    apolice.Placa = model.Placa;
                    apolice.ValorPremio = model.ValorPremio;

                   _seguroDBContext.Update(apolice);
                   _seguroDBContext.SaveChanges();
                    oRet.setSuccesso();
                }
            }
            catch (System.Exception ex)
            {
                oRet.setErro(ex.Message);
            }
            return oRet;
        }
        public Retorno Delete(int id)
        {
            Retorno oRet = new Retorno();
            try
            {
                var apolice = (from p in _seguroDBContext.Apolice
                               where p.NumApolice == id
                               select p).FirstOrDefault();
                if (apolice != null)
                {
                    _seguroDBContext.Remove(apolice);
                    _seguroDBContext.SaveChanges();
                    oRet.setSuccesso();
                }

            }
            catch (System.Exception ex)
            {
                oRet.setErro(ex.Message);
            }
            return oRet;
        }
    }
}
