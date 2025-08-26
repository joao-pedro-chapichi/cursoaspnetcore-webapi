namespace CursoAPIWeb.Objects.Dtos.Entities
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email
        {
            // Podemos definir processamentos ao pegar ou definir o valor de um campo
            // Isso é útil caso desejamos formatar ou validar os dados
            get => _email;
            set => _email = value.ToLower();
        }
        private string _email; // Campo privado para armazenar o valor real do processamento acima
        public int EstadoMatricula { get; set; }
        public int ProfessorId { get; set; }
    }
}
