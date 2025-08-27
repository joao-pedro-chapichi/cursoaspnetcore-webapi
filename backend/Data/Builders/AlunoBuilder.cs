using Microsoft.EntityFrameworkCore;
using CursoAPIWeb.Objects.Enums;
using CursoAPIWeb.Objects.Models;

namespace CursoAPIWeb.Data.Builders;

public class AlunoBuilder
{
    public static void Build(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
        modelBuilder.Entity<Aluno>().Property(a => a.Nome).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Aluno>().Property(a => a.Telefone).IsRequired().HasMaxLength(11);
        modelBuilder.Entity<Aluno>().Property(a => a.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Aluno>().Property(a => a.EstadoMatricula).IsRequired();
        modelBuilder.Entity<Aluno>().Property(a => a.ProfessorId).IsRequired();

        modelBuilder.Entity<Aluno>()
            .HasData(new List<Aluno>
            {
                new (1, "Miguel Silva", "17995361829", "miguelsilva@gmail.com", EstadoMatricula.ATIVA, 1),
                new (2, "Gabriel Oliveira", "17996125387", "gabrieloliveira@gmail.com", EstadoMatricula.CANCELADA, 1),
                new (3, "Marco Brito", "17996579012", "marcobrito@gmail.com", EstadoMatricula.SUSPENSA, 1)
            });
    }
}
