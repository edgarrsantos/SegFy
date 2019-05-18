using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Retorno
    {
        public String Mensagem { get; set; }
        public Boolean Erro { get; set; }
        public Int32 Codigo { get; set; }
        public String URL { get; set; }
        public List<RetornoAlerta> Alertas { get; set; }

        public Retorno()
        {
            this.Alertas = new List<RetornoAlerta>();
        }

        public void setSuccesso()
        {
            setSuccesso(null);
        }
        public void setSuccesso(string _mensagem)
        {
            this.Erro = false;
            this.Codigo = 0;
            this.Mensagem = string.IsNullOrEmpty(_mensagem) ? "Ação realizada com sucesso!" : _mensagem;
        }


        public void setErro()
        {
            setErro(null, 0);
        }
        public void setErro(string _mensagem)
        {
            setErro(_mensagem, 0);
        }
        public void setErro(int _codigo)
        {
            setErro(null, _codigo);
        }
        public void setErro(string _mensagem, int _codigo)
        {
            this.Erro = true;
            this.Codigo = _codigo == 0 ? 1 : _codigo;
            this.Mensagem = string.IsNullOrEmpty(_mensagem) ? "Um erro inesperado ocorreu!" : _mensagem;
        }
    }

    public class Retorno<T> : Retorno
    {
        public T Object { get; set; }

        public Retorno()
        {
            this.Alertas = new List<RetornoAlerta>();
        }
    }

    public class RetornoAlerta
    {
        public string Mensagem { get; set; }
        public List<string> SubMensagem { get; set; }

        public RetornoAlerta()
        {
            this.SubMensagem = new List<string>();
        }
        public RetornoAlerta(string _mensagem)
        {
            this.Mensagem = _mensagem;
            this.SubMensagem = new List<string>();
        }
    }

    public static class ReturnExtensions
    {
        public static void AdicionarAlerta(this List<RetornoAlerta> list, string _mensagem)
        {
            if (list == null)
                list = new List<RetornoAlerta>();

            list.Add(new RetornoAlerta(_mensagem));
        }
        public static void Adicionar(this List<string> list, string _mensagem)
        {
            if (list == null)
                list = new List<string>();

            list.Add(_mensagem);
        }
    }
}