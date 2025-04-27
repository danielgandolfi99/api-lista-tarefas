namespace ListaTarefasApi.Models
{
    public class Tarefa
    {
        public int? id_tarefa { get; set; }
        public string? titulo { get; set; }
        public string? descricao { get; set; }
        public DateTime? dt_criacao { get; set; }
        public DateTime? dt_conclusao { get; set; }
    }
}
