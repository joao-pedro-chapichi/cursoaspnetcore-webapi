using System.ComponentModel.DataAnnotations.Schema;

namespace CursoAPIWeb.Objects.Models;

[Table("professor")]
public class Professor
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("senha")]
    public string Senha { get; set; }

    public Professor() { }

    public Professor(int id, string nome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}
