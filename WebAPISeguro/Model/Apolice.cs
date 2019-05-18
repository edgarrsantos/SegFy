using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //utilizado para configurar o nome da tabela correspondente no banco de dados
    [Table("tb_apolice")]
    public class Apolice
    {
        // Precisa definir a chave para não ter problema ao gerar o banco de forma automatica
        [Key]
        public int NumApolice { get; set; }
        public string CPFCNPJ { get; set; }
        public string Placa { get; set; }
        public decimal ValorPremio { get; set; }
    }
}
