namespace CursoAPIWeb.Objects.Dtos.Entities;

public class ProfessorDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email
    {
        get => _email;
        set => _email = value.ToLower();
    }
    private string _email;
    public string Senha { get; set; }
}
