using System;

namespace WebApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public TipoPrioridadeEnum Prioridade { get; set; }
        public TipoStatusEnum Status { get; set; }
        public byte[]? FotoTarefa { get; set; }
    }
    



}
