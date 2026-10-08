namespace Projetomecanica.Api.Models
{
    public class Agendamento
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int Horario { get; set; }
        public string Serviço { get; set; }
        public decimal preco { get; set; }
    }
}
