using CursoAPIWeb.Objects.Enums;
using CursoAPIWeb.Objects.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoAPIWeb.Objects.Models;

[Table("aluno")]
public class Aluno
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; }

    [Column("telefone")]
    public string Telefone { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("estadomatricula")]
    public EstadoMatricula EstadoMatricula { get; set; }

    // Chave estrangeira vinda da classe Professor (Relacionamento N - 1)
    // Primeiro declaramos um campo para a chave
    // E então, declaramos um objeto da classe que estamos pegando essa chave
    [Column("professorid")]
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; } = null!;

    public Aluno() { }

    public Aluno(int id, string nome, string telefone, string email, EstadoMatricula estadoMatricula, int professorId)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        EstadoMatricula = estadoMatricula;
        ProfessorId = professorId;
    }
}